use super::*;

const TPKT_CLIENT_CONNECTION_REQUEST_PACKET: [u8; 44] = [
    0x03, 0x00, 0x00, 0x2c, 0x27, 0xe0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x6f, 0x6f, 0x6b, 0x69, 0x65, 0x3a, 0x20,
    0x6d, 0x73, 0x74, 0x73, 0x68, 0x61, 0x73, 0x68, 0x3d, 0x65, 0x6c, 0x74, 0x6f, 0x6e, 0x73, 0x0d, 0x0a, 0x01, 0x00,
    0x08, 0x00, 0x00, 0x00, 0x00, 0x00,
];
const TPKT_CLIENT_MCS_CONNECT_INITIAL_PACKET: [u8; 416] = [
    0x03, 0x00, 0x01, 0xa0, 0x02, 0xf0, 0x80, 0x7f, 0x65, 0x82, 0x01, 0x94, 0x04, 0x01, 0x01, 0x04, 0x01, 0x01, 0x01,
    0x01, 0xff, 0x30, 0x19, 0x02, 0x01, 0x22, 0x02, 0x01, 0x02, 0x02, 0x01, 0x00, 0x02, 0x01, 0x01, 0x02, 0x01, 0x00,
    0x02, 0x01, 0x01, 0x02, 0x02, 0xff, 0xff, 0x02, 0x01, 0x02, 0x30, 0x19, 0x02, 0x01, 0x01, 0x02, 0x01, 0x01, 0x02,
    0x01, 0x01, 0x02, 0x01, 0x01, 0x02, 0x01, 0x00, 0x02, 0x01, 0x01, 0x02, 0x02, 0x04, 0x20, 0x02, 0x01, 0x02, 0x30,
    0x1c, 0x02, 0x02, 0xff, 0xff, 0x02, 0x02, 0xfc, 0x17, 0x02, 0x02, 0xff, 0xff, 0x02, 0x01, 0x01, 0x02, 0x01, 0x00,
    0x02, 0x01, 0x01, 0x02, 0x02, 0xff, 0xff, 0x02, 0x01, 0x02, 0x04, 0x82, 0x01, 0x33, 0x00, 0x05, 0x00, 0x14, 0x7c,
    0x00, 0x01, 0x81, 0x2a, 0x00, 0x08, 0x00, 0x10, 0x00, 0x01, 0xc0, 0x00, 0x44, 0x75, 0x63, 0x61, 0x81, 0x1c, 0x01,
    0xc0, 0xd8, 0x00, 0x04, 0x00, 0x08, 0x00, 0x00, 0x05, 0x00, 0x04, 0x01, 0xca, 0x03, 0xaa, 0x09, 0x04, 0x00, 0x00,
    0xce, 0x0e, 0x00, 0x00, 0x45, 0x00, 0x4c, 0x00, 0x54, 0x00, 0x4f, 0x00, 0x4e, 0x00, 0x53, 0x00, 0x2d, 0x00, 0x44,
    0x00, 0x45, 0x00, 0x56, 0x00, 0x32, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00,
    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0c, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0xca,
    0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x18, 0x00, 0x07, 0x00, 0x01, 0x00, 0x36, 0x00, 0x39, 0x00, 0x37, 0x00, 0x31,
    0x00, 0x32, 0x00, 0x2d, 0x00, 0x37, 0x00, 0x38, 0x00, 0x33, 0x00, 0x2d, 0x00, 0x30, 0x00, 0x33, 0x00, 0x35, 0x00,
    0x37, 0x00, 0x39, 0x00, 0x37, 0x00, 0x34, 0x00, 0x2d, 0x00, 0x34, 0x00, 0x32, 0x00, 0x37, 0x00, 0x31, 0x00, 0x34,
    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0xc0, 0x0c, 0x00, 0x0d, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02,
    0xc0, 0x0c, 0x00, 0x1b, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0xc0, 0x2c, 0x00, 0x03, 0x00, 0x00, 0x00,
    0x72, 0x64, 0x70, 0x64, 0x72, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x80, 0x63, 0x6c, 0x69, 0x70, 0x72, 0x64, 0x72,
    0x00, 0x00, 0x00, 0xa0, 0xc0, 0x72, 0x64, 0x70, 0x73, 0x6e, 0x64, 0x00, 0x00, 0x00, 0x00, 0x00, 0xc0,
];
const TPKT_CLIENT_MCS_ERECT_DOMAIN_PACKET: [u8; 12] =
    [0x03, 0x00, 0x00, 0x0c, 0x02, 0xf0, 0x80, 0x04, 0x01, 0x00, 0x01, 0x00];
const TPKT_CLIENT_MCS_ATTACH_USER_REQUEST_PACKET: [u8; 8] = [0x03, 0x00, 0x00, 0x08, 0x02, 0xf0, 0x80, 0x28];
const TPKT_CLIENT_MCS_ATTACH_USER_CONFIRM_PACKET: [u8; 94] = [
    0x03, 0x00, 0x00, 0x5e, 0x02, 0xf0, 0x80, 0x64, 0x00, 0x06, 0x03, 0xeb, 0x70, 0x50, 0x01, 0x02, 0x00, 0x00, 0x48,
    0x00, 0x00, 0x00, 0x91, 0xac, 0x0c, 0x8f, 0x64, 0x8c, 0x39, 0xf4, 0xe7, 0xff, 0x0a, 0x3b, 0x79, 0x11, 0x5c, 0x13,
    0x51, 0x2a, 0xcb, 0x72, 0x8f, 0x9d, 0xb7, 0x42, 0x2e, 0xf7, 0x08, 0x4c, 0x8e, 0xae, 0x55, 0x99, 0x62, 0xd2, 0x81,
    0x81, 0xe4, 0x66, 0xc8, 0x05, 0xea, 0xd4, 0x73, 0x06, 0x3f, 0xc8, 0x5f, 0xaf, 0x2a, 0xfd, 0xfc, 0xf1, 0x64, 0xb3,
    0x3f, 0x0a, 0x15, 0x1d, 0xdb, 0x2c, 0x10, 0x9d, 0x30, 0x11, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
];
const FASTPATH_PACKET: [u8; 17] = [
    0xc4, 0x11, 0x30, 0x35, 0x6b, 0x5b, 0xb5, 0x34, 0xc8, 0x47, 0x26, 0x18, 0x5e, 0x76, 0x0e, 0xde, 0x28,
];

const TPKT_SERVER_MCS_DATA_INDICATION_DVC_CREATE_REQUEST_PACKET: [u8; 66] = [
    0x03, 0x00, 0x00, 0x42, 0x02, 0xf0, 0x80, 0x68, 0x00, 0x01, 0x03, 0xef, 0xf0, 0x34, 0x2c, 0x00, 0x00, 0x00, 0x03,
    0x00, 0x00, 0x00, 0x10, 0x0a, 0x4d, 0x69, 0x63, 0x72, 0x6f, 0x73, 0x6f, 0x66, 0x74, 0x3a, 0x3a, 0x57, 0x69, 0x6e,
    0x64, 0x6f, 0x77, 0x73, 0x3a, 0x3a, 0x52, 0x44, 0x53, 0x3a, 0x3a, 0x47, 0x65, 0x6f, 0x6d, 0x65, 0x74, 0x72, 0x79,
    0x3a, 0x3a, 0x76, 0x30, 0x38, 0x2e, 0x30, 0x31, 0x00,
];

const TPKT_CLIENT_MCS_DATA_REQUEST_DVC_CREATE_RESPONSE_PACKET: [u8; 28] = [
    0x03, 0x00, 0x00, 0x1c, 0x02, 0xf0, 0x80, 0x64, 0x00, 0x01, 0x03, 0xef, 0xf0, 0x0e, 0x06, 0x00, 0x00, 0x00, 0x03,
    0x00, 0x00, 0x00, 0x10, 0x0a, 0x00, 0x00, 0x00, 0x00,
];

const CHANNEL_DVC_CREATE_REQUEST_PACKET: [u8; 52] = [
    0x2c, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x10, 0x0a, 0x4d, 0x69, 0x63, 0x72, 0x6f, 0x73, 0x6f, 0x66, 0x74,
    0x3a, 0x3a, 0x57, 0x69, 0x6e, 0x64, 0x6f, 0x77, 0x73, 0x3a, 0x3a, 0x52, 0x44, 0x53, 0x3a, 0x3a, 0x47, 0x65, 0x6f,
    0x6d, 0x65, 0x74, 0x72, 0x79, 0x3a, 0x3a, 0x76, 0x30, 0x38, 0x2e, 0x30, 0x31, 0x00,
];

const TPKT_SERVER_MCS_DATA_INDICATION_DVC_DATA_PACKET: [u8; 70] = [
    0x03, 0x00, 0x00, 0x46, 0x02, 0xf0, 0x80, 0x68, 0x00, 0x01, 0x03, 0xef, 0xf0, 0x38, 0x30, 0x00, 0x00, 0x00, 0x03,
    0x00, 0x00, 0x00, 0x34, 0x0a, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71,
    0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71,
    0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71,
];

const DVC_DATA_PACKET: [u8; 46] = [
    0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71,
    0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71,
    0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71, 0x71,
];

const DRDYNVC_CHANNEL_ID: u16 = 1007;

#[test]
fn correct_reads_single_tpkt_packet() {
    let packet = TPKT_CLIENT_CONNECTION_REQUEST_PACKET.to_vec();
    let mut data = packet.clone();

    let (messages, _) = get_tpkt_tpdu_messages(&mut data);
    assert_eq!(1, messages.len());
    assert_eq!(packet, messages.first().unwrap().to_owned());
}

#[test]
fn does_not_read_fastpath_packet() {
    let packet = FASTPATH_PACKET.to_vec();
    let mut data = packet.clone();

    let (messages, fast_path_length) = get_tpkt_tpdu_messages(&mut data);
    assert_eq!(FASTPATH_PACKET.len(), fast_path_length);
    assert!(messages.is_empty());
}

#[test]
fn does_not_read_incomplete_tpkt_packet() {
    let mut packet = TPKT_CLIENT_CONNECTION_REQUEST_PACKET.to_vec();
    packet.split_off(3);
    let mut data = packet.clone();
    let (messages, _) = get_tpkt_tpdu_messages(&mut data);
    assert!(messages.is_empty());
}

#[test]
fn does_not_read_incomplete_packet_on_multiple_calls() {
    let mut packet = TPKT_CLIENT_CONNECTION_REQUEST_PACKET.to_vec();
    packet.split_off(3);
    let mut data = packet.clone();

    let (messages, _) = get_tpkt_tpdu_messages(&mut data);
    assert!(messages.is_empty());

    let (messages, _) = get_tpkt_tpdu_messages(&mut data);
    assert!(messages.is_empty());
}

#[test]
fn reads_packet_on_second_call_after_incomplete_read() {
    let packet = TPKT_CLIENT_CONNECTION_REQUEST_PACKET.to_vec();
    let (packet_first_part, packet_second_part) = packet.split_at(3);
    let mut data = packet_first_part.to_vec();

    let (messages, _) = get_tpkt_tpdu_messages(&mut data);
    assert!(messages.is_empty());

    data.extend(packet_second_part);
    let (messages, _) = get_tpkt_tpdu_messages(&mut data);
    assert_eq!(1, messages.len());
    assert_eq!(packet, messages.first().unwrap().to_owned());
}

#[test]
fn reads_multiple_packets_after_incomplete_call() {
    let first_packet = TPKT_CLIENT_CONNECTION_REQUEST_PACKET.to_vec();
    let second_packet = FASTPATH_PACKET.to_vec();
    let third_packet = TPKT_CLIENT_CONNECTION_REQUEST_PACKET.to_vec();
    let (first_packet_first_part, second_packet_second_part) = first_packet.split_at(3);
    let mut data = first_packet_first_part.to_vec();

    let (messages, _) = get_tpkt_tpdu_messages(&mut data);
    assert!(messages.is_empty());

    data.extend(second_packet_second_part);
    data.extend_from_slice(second_packet.as_ref());
    data.extend_from_slice(third_packet.as_ref());
    let (messages, fast_path_length) = get_tpkt_tpdu_messages(&mut data);
    
    assert_eq!(2, messages.len());
    assert_eq!(first_packet, messages.first().unwrap().to_owned());
    assert_eq!(third_packet, messages.last().unwrap().to_owned());
    assert_eq!(FASTPATH_PACKET.len(), fast_path_length);
}

#[test]
fn reads_bunch_of_packets() {
    let mut packets = vec![
        TPKT_CLIENT_CONNECTION_REQUEST_PACKET.to_vec(),
        TPKT_CLIENT_MCS_CONNECT_INITIAL_PACKET.to_vec(),
        TPKT_CLIENT_MCS_ERECT_DOMAIN_PACKET.to_vec(),
        TPKT_CLIENT_MCS_ATTACH_USER_REQUEST_PACKET.to_vec(),
        TPKT_CLIENT_MCS_ATTACH_USER_CONFIRM_PACKET.to_vec(),
        FASTPATH_PACKET.to_vec(),
    ];
    let mut data = packets.iter().cloned().flatten().collect::<Vec<_>>();
    let (messages, fast_path_length) = get_tpkt_tpdu_messages(&mut data);

    assert_eq!(FASTPATH_PACKET.len(), fast_path_length);

    // because fast-path is skipped
    assert_eq!(packets.len() - 1, messages.len());
    packets.pop();

    assert_eq!(packets, messages);
}

#[test]
fn reads_bunch_of_packets_with_last_incomplete_pockets() {
    let mut incomplete_packet = TPKT_CLIENT_MCS_ATTACH_USER_CONFIRM_PACKET.to_vec();
    incomplete_packet.split_off(3);
    let mut packets = vec![
        TPKT_CLIENT_CONNECTION_REQUEST_PACKET.to_vec(),
        TPKT_CLIENT_MCS_CONNECT_INITIAL_PACKET.to_vec(),
        TPKT_CLIENT_MCS_ERECT_DOMAIN_PACKET.to_vec(),
        TPKT_CLIENT_MCS_ATTACH_USER_REQUEST_PACKET.to_vec(),
        incomplete_packet,
    ];
    let mut data = packets.iter().cloned().flatten().collect::<Vec<_>>();

    let (messages, _)= get_tpkt_tpdu_messages(&mut data);
    assert_eq!(packets.len() - 1, messages.len());
    packets.pop();
    assert_eq!(packets, messages);
}

#[test]
fn reads_windows_style_first_bunch_of_packets() {
    let packet = TPKT_CLIENT_CONNECTION_REQUEST_PACKET.to_vec();
    let mut data = vec![0x00; 4];
    data.extend_from_slice(packet.as_ref());

    let (messages, _) = get_tpkt_tpdu_messages(&mut data);
    assert_eq!(1, messages.len());
    assert_eq!(packet, messages.first().unwrap().to_owned());
}

#[test]
fn does_not_parse_fast_path_pdu() {
    let packet = FASTPATH_PACKET.to_vec();
    let mut data = packet.clone();

    match parse_tpkt_tpdu_message(&mut data) {
        Err(_) => (),
        res => panic!("Expected error, got: {:?}", res),
    }
}

#[test]
fn does_not_parse_invalid_tpkt_tpdu() {
    let mut packet = TPKT_SERVER_MCS_DATA_INDICATION_DVC_CREATE_REQUEST_PACKET.to_vec();
    packet.split_off(3);
    let mut data = packet.clone();

    match parse_tpkt_tpdu_message(&mut data) {
        Err(_) => (),
        res => panic!("Expected error, got: {:?}", res),
    }
}

#[test]
fn does_not_parse_unsuitable_tpkt_mcs_pdu() {
    let packet = TPKT_CLIENT_MCS_ATTACH_USER_REQUEST_PACKET.to_vec();
    let mut data = packet.clone();

    match parse_tpkt_tpdu_message(&mut data) {
        Err(_) => (),
        res => panic!("Expected error, got: {:?}", res),
    }
}

#[test]
fn parses_tpkt_channel_pdu() {
    let packet = TPKT_SERVER_MCS_DATA_INDICATION_DVC_CREATE_REQUEST_PACKET.to_vec();
    let mut data = packet.clone();

    let (channel_id, channel_message) = parse_tpkt_tpdu_message(&mut data).unwrap();

    assert_eq!(DRDYNVC_CHANNEL_ID, channel_id);

    let expected_channel_message = CHANNEL_DVC_CREATE_REQUEST_PACKET.to_vec();
    assert_eq!(expected_channel_message, channel_message);
}

#[test]
fn message_reader_correct_reads_dvc_data_packet() {
    let mut channels = HashMap::new();
    channels.insert("drdynvc".to_string(), DRDYNVC_CHANNEL_ID);
    let mut rdp_message_reader = RdpMessageReader::new(channels);

    let mut first_packet = TPKT_SERVER_MCS_DATA_INDICATION_DVC_CREATE_REQUEST_PACKET.to_vec();
    let mut messages = rdp_message_reader.get_messages(&mut first_packet, PduSource::Server);
    assert!(messages.is_empty());

    let mut second_packet = TPKT_CLIENT_MCS_DATA_REQUEST_DVC_CREATE_RESPONSE_PACKET.to_vec();
    messages = rdp_message_reader.get_messages(&mut second_packet, PduSource::Client);
    assert!(messages.is_empty());

    let mut third_packet = TPKT_SERVER_MCS_DATA_INDICATION_DVC_DATA_PACKET.to_vec();
    messages = rdp_message_reader.get_messages(&mut third_packet, PduSource::Server);

    let expected_dvc_message = DVC_DATA_PACKET.to_vec();
    assert_eq!(expected_dvc_message, messages.first().unwrap().to_owned());
}
