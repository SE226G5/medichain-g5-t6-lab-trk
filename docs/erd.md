sample {
        varchar(50) sample_id PK
        varchar(100) client_name
        varchar(100) analysis_type
        timestamp receipt_time
    }
    stage {
        int stage_id PK
        varchar(100) stage_name
        interval allowed_duration
    }
    trackingentry {
        int tracking_id PK
        varchar(50) sample_id FK
        int stage_id FK
        int user_id FK
        timestamp entry_time
        timestamp exit_time
        interval time_spent
    }
    users {
        int user_id PK
        varchar(100) username
        varchar(100) password
        varchar(50) role
    }
    alert {
        int alert_id PK
        int tracking_id FK
        varchar(50) sample_id FK
        interval delay_duration
        varchar(100) responsible
    }
    %% RELATIONSHIPS
    sample ||--o{ trackingentry : "has"
    stage  ||--o{ trackingentry : "has"
    users  ||--o{ trackingentry : "performed by"
trackingentry ||--|| alert : "generates"
    sample        ||--o{ alert : "related to"