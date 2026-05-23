# API Specifications (LAB-TRK)

## 1. Overview
The LAB-TRK module handles operational logs, calculates processing duration between laboratory stages (e.g., Receipt, Analysis, Review), and generates automated delay alerts when a sample exceeds its allocated time limit[span_1](start_span)[span_1](end_span).

---

## 2. Main Endpoints

### Endpoint 1: Document Sample Stage Transition
* Method: POST
* Route: /api/v1/tracking/logs
* What it does: Logs the transition of a sample from a source stage to a destination stage[span_2](start_span)[span_2](end_span). The system backend automatically calculates the time elapsed in minutes and sets the delayAlertFlag to true if it exceeds the step's threshold[span_3](start_span)[span_3](end_span).

* Required Data (Request Body):
`json
{
  "sampleId": "SMP-8832",
  "stageSource": "Received",
  "stageDest": "Analysis",
  "responsibleUser": "User_ID_44"

}
Returned Data (Response - 200 OK):
{
  "logId": "LOG-9921",
  "durationCalculationMinutes": 15,
  "delayAlertFlag": false
}
Endpoint 2: Get Sample Tracking History
​Method: GET
​Route: /api/v1/tracking/samples/:sampleId
​What it does: Retrieves the full lifecycle log and audit trail of a specific sample, showing every stage transition, time taken, and the responsible user.
​Required Data: sampleId (Passed as a URL parameter)
​Returned Data (Response - 200 OK):
{
  "sampleId": "SMP-8832",
  "currentStage": "Analysis",
  "trackingHistory": [
    {
      "logId": "LOG-9920",
      "stageSource": "Registered",
      "stageDest": "Received",
      "durationMinutes": 10,
      "timestamp": "2026-05-23T17:45:00Z",
      "responsibleUser": "User_ID_12"
    },
    {
      "logId": "LOG-9921",
      "stageSource": "Received",
      "stageDest": "Analysis",
      "durationMinutes": 15,
      "timestamp": "2026-05-23T18:00:00Z",
      "responsibleUser": "User_ID_44"
    }
  ]
}
Endpoint 3: Fetch Active Delay Alerts
​Method: GET
​Route: /api/v1/tracking/alerts/delayed
​What it does: Returns a list of all current operational samples that have triggered a delay alert (delayAlertFlag: true), allowing administrators to take immediate actions.
​Required Data: None
​Returned Data (Response - 200 OK):
{
  "totalDelayed": 1,
  "alerts": [
    {
      "sampleId": "SMP-8832",
      "currentStage": "Analysis",
      "minutesDelayed": 45,
      "thresholdExceededMinutes": 30
    }
  ]
}
