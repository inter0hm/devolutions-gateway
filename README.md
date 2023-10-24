# Devolutions Gateway

[![Build Status](https://github.com/Devolutions/devolutions-gateway/actions/workflows/ci.yml/badge.svg)](https://github.com/Devolutions/devolutions-gateway/actions/workflows/ci.yml)

A blazing fast relay server adaptable to different protocols and desired levels of traffic inspection.

## Install

### Using the Devolutions Server Management Console

Download from [Devolutions official website][official_website].

### Using the offline Windows Installer

Download from [Devolutions official website][official_website] or the [GitHub releases page][github_release].

### From GitHub

Signed binaries and installers are available for all versions are available at all times from the
[GitHub releases page][github_release].

### From sources

Ensure that you have [the Rust toolchain installed][install_rust], then clone this repository and run:

```shell
cargo install --path ./devolutions-gateway
```

## Configuration

Devolutions Gateway is configured using a JSON document.
The recommended way to modify this document is to use [the PowerShell module][psmodule],
but it is nonetheless possible to modify it manually or by any other means that are convenient for you.

The file containing this JSON document must be named `gateway.json` and exist under the following path,
depending on your platform:

| Platform       | Path                                                |
| -------------- | --------------------------------------------------- |
| Windows        | `%ProgramData%\Devolutions\Gateway\`                |
| Linux          | `/etc/devolutions-gateway/`                         |
| macOS (Darwin) | `/Library/Application Support/devolutions-gateway/` |

This path may be overridden using the `DGATEWAY_CONFIG_PATH` environment variable.

A default template with minimal options is generated at this location on startup if the file doesn't exist yet.

Stable options are:

- **Id** (_UUID_): This Gateway's UUID.

- **Hostname** (_String_): This Gateway's hostname (used when inferring external URLs).

- **ProvisionerPublicKeyFile** (_FilePath_): Path to the provisioner public key which used to verify tokens
    without any specific restriction.

- **SubProvisionerPublicKey** (_Object_): A JSON object describing the sub provisioner public key which may only be used to verify
    tokens when establishing a session.
    
    The schema is:

    * **Id** (_UUID_): The key ID for this subkey.
    * **Value** (_String_): The binary-to-text-encoded key data.

    * **Format** (_String_): The format used for the key data.
        
        Possible values:
        
        * `Spki` (default)
        * `Rsa`

    * **Encoding** (_String_): The binary-to-text encoding used for the key data.

        Possible values:
        
        * `Multibase` (default)
        * `Base64`
        * `Base64Pad`
        * `Base64Url`
        * `Base64UrlPad`

- **DelegationPrivateKeyFile** (_FilePath_): Path to the delegation private key (used to decipher sensitive data from tokens).

- **TlsCertificateSource** (_String_): Source for the TLS certificate. Possible values are: `External` (default), `System`.

- **TlsCertificateSubjectName** (_String_): Subject name of the certificate to use for TLS when using system source.

- **TlsCertificateStoreName** (_String_): Name of the System Certificate Store to use for TLS (default is `My`).

- **TlsCertificateStoreLocation** (_String_): Location of the System Certificate Store to use for TLS.

    Possible values:

    * `CurrentUser` (default)
    * `CurrentService`
    * `LocalMachine`

- **TlsCertificateFile** (_FilePath_): Path to the certificate to use for TLS.

- **TlsPrivateKeyFile** (_FilePath_): Path to the private key to use for TLS.

- **Listeners** (_Array_): Array of listener URLs.

    Each element has the following schema: 

    * **InternalUrl** (_URL_): Internal URL for this listener, a socket bound to the specified address
        (IP address, and port number) will be created.

    * **ExternalUrl** (_URL_): External URL for this listener, accessing this URL from outside should
        ultimately redirect to the service. This holds no meaning for the service itself, but the value
        will be advertised by the `GET /jet/diagnostics/configuration` HTTP endpoint.
        This route can be used by other systems to automatically discover the remaining access URLs.

    For both values, host segment may be abridged with `*`.

    When used in internal URLs, `*` will cause two listeners to be created with `*` expanded into:
    - the IPv4 wildcard bind address `0.0.0.0`, for listening to any IPv4 address, and
    - the IPv6 wildcard bind address `[::]`, for listening to any IPv6 address.

    When used in external URLs, `*` will be expanded into the value of `Hostname`.

- **Subscriber** (_Object_): Subscriber API configuration.
    
    * **Url** (_URL_): HTTP URL where notification messages are to be sent.
    * **Token** (_String_): bearer token to use when making HTTP requests.

- **RecordingPath** (_FilePath_): Path to the recordings folder.

- **Ngrok** (_Object_): JSON object describing the ngrok configuration for ingress listeners.

    * **AuthToken** (_String_): Specifies the authentication token used to connect to the ngrok service.
    * **HeartbeatInterval** (_Integer_): How often the service should heartbeat to the ngrok servers defined as a number in seconds.
    * **HeartbeatTolerance** (_Integer_): Reconnect the agent tunnel session if the server does not respond to a heartbeat within this
        tolerance defined as a number in seconds.
    * **Metadata** (_String_): Opaque, user-supplied string that will be returned as part of the ngrok API response to the list
        online sessions resource for all tunnels started by Devolutions Gateway service.
    * **ServerAddr** (_URL_): This is the URL of the ngrok server to connect to. You should only set this if you are using a
        custom ingress URL.

    * **Tunnels** (_Map_): A map of ngrok tunnels. The key is the name of the tunnel and value is a JSON object whose schema
        depends on tunnel protocol.

        Common options are:

        * **AllowCidrs** (_Array_): Array of CIDRs, rejects connections that do not match the given CIDRs.
        * **DenyCidrs** (_Array_): Array of CIDRS, rejects connections that match the given CIDRs and allows all other CIDRs.
        * **Metadata** (_String_): Arbitrary user-defined metadata that will appear in the ngrok service API when listing tunnel sessions.

        Other options for an HTTP tunnel are:

        * **Proto** (_String_): MUST be set to `http`.
        * **Domain** (_String_): The domain to request, as registered in the ngrok dashboard.
        * **Metadata** (_String_): Arbitrary user-defined metadata that will appear in the ngrok service API when listing tunnel sessions.
        * **CircuitBreaker** (_Ratio_): Reject requests when 5XX responses exceed this ratio.
        * **Compression** (_Boolean_): Enable gzip compression for HTTP responses.

        Other options for a TCP tunnel are:

        * **Proto** (_String_): MUST be set to `tcp`.
        * **RemoteAddr** (_String_): Bind the remote TCP address and port, as registered in the ngrok dashboard.

        Note that in order to accept connections from outside, you must at least configure `AllowCidrs`.
        The most permissive CIDR is the "zero-address" `0.0.0.0/0`, and defines an IP block containing all possible IP addresses.

- **VerbosityProfile** (_String_): Logging verbosity profile (pre-defined tracing directives).

    Possible values:

    * `Default` (default): The default profile.
    * `Debug`: Recommended profile for developers.
    * `Tls`: Verbose logging for TLS troubleshooting.
    * `All`: Extra-verbose profile, showing all traces.
    * `Quiet`: Only show warnings and errors.

## Troubleshooting

### Connection from Microsoft Windows 7/8/8.1/Server 2008/Server 2012 clients

1. For Window 7 and Windows Server 2008: Install latest updates. Make sure to
   install the update that adds
   [support for TLS 1.1 and TLS 1.2](https://support.microsoft.com/en-au/help/3080079/update-to-add-rds-support-for-tls-1-1-and-tls-1-2-in-windows-7-or-wind).
   This is not required for newer Windows editions - they support TLS 1.1 and TLS 1.2 by default.

1. Add following cipher suites to the SSL Cipher Suite order:
    - TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256;
    - TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384.

    To add cipher suites, use the group policy setting SSL Cipher Suite Order
    under Computer Configuration > Administrative Templates > Network > SSL
    Configuration Settings.
    [TLS Cipher Suites in Windows 7](https://docs.microsoft.com/en-us/windows/win32/secauthn/tls-cipher-suites-in-windows-7).

### Redirection to Microsoft Windows 7/8/8.1/Server 2008/Server 2012 server

Unfortunately, Microsoft Windows 7/8/8.1/Server 2008/Server 2012 machines
cannot accept connections from [rustls] client.
Support for required cipher suits was not implemented until Windows 10.

### `NoCipherSuitesInCommon` error on Windows with a custom SChannel configuration

If you tried to to explicitly enable hashing algorithms like `SHA256` in registry keys under
`HKLM\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Hashes`, it turns out that this will…
disable them, even if you set `Enabled` to `1`. For example, if the only hashing algorithm that
is not explicitly set is `SHA1`, the SChannel client only advertises `SHA1`, which is not supported
anymore by default.

See [this page from Microsoft documentation][microsoft_tls] to learn how to properly configure SChannel.

### More

Read [our knowledge base](https://docs.devolutions.net/kb/devolutions-gateway/).

## Cookbook

See [COOKBOOK.md](./docs/COOKBOOK.md).

## Continuous Integration and Delivery

See the dedicated [README.md file](./.github/workflows/README.md) in the `workflows` directory.

<!-- links -->

[official_website]: https://devolutions.net/gateway/download/
[github_release]: https://github.com/Devolutions/devolutions-gateway/releases
[install_rust]: https://www.rust-lang.org/tools/install
[psmodule]: https://www.powershellgallery.com/packages/DevolutionsGateway/
[rustls]: https://crates.io/crates/rustls
[microsoft_tls]: https://learn.microsoft.com/en-us/windows-server/security/tls/tls-registry-settings
