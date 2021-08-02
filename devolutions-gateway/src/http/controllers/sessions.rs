use crate::http::guards::access::{AccessGuard, JetAccessType};
use crate::http::HttpErrorStatus;
use crate::{GatewaySessionInfo, SESSIONS_IN_PROGRESS};
use jet_proto::token::JetAccessScope;
use saphir::controller::Controller;
use saphir::http::{Method, StatusCode};
use saphir::macros::controller;
use saphir::prelude::Json;

pub struct SessionsController;

#[controller(name = "sessions")]
impl SessionsController {
    #[get("/count")]
    #[guard(
        AccessGuard,
        init_expr = r#"JetAccessType::Scope(JetAccessScope::GatewaySessionsRead)"#
    )]
    async fn get_count(&self) -> (StatusCode, String) {
        let sessions = SESSIONS_IN_PROGRESS.read().await;
        (StatusCode::OK, sessions.len().to_string())
    }

    #[get("/")]
    #[guard(
        AccessGuard,
        init_expr = r#"JetAccessType::Scope(JetAccessScope::GatewaySessionsRead)"#
    )]
    async fn get_sessions(&self) -> Result<Json<Vec<GatewaySessionInfo>>, HttpErrorStatus> {
        let sessions = SESSIONS_IN_PROGRESS.read().await;

        let sessions_in_progress: Vec<GatewaySessionInfo> = sessions.values().map(|x| x.clone()).collect();

        Ok(Json(sessions_in_progress))
    }
}
