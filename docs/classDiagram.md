classDiagram

    class Sample {
        -String sampleID
        -String clientName
        -String analysisType
        -DateTime receiptTime
        +registerSample()
    }

    class Stage {
        -String stageName
        -Time allowedDuration
    }

    class User {
        -String username
        -Pwd password
        -String role
        +login()
    }

    class TrackingEntry {
        -DateTime entryTime
        -DateTime exitTime
        -Time timeSpent
        +startStage()
        +endStage()
        +checkDelay()
    }

    class Alert {
        -String sampleID
        -Time delayDuration
        -String responsible
        +generateAlert()
    }

    %% RELATIONSHIPS (exactly like your diagram)
    Sample "1" --> "*" TrackingEntry : has
    Stage "1" --> "*" TrackingEntry : in_stage
    User "1" --> "*" TrackingEntry : performed_by
    TrackingEntry "0..1" --> "0..1" Alert : generates