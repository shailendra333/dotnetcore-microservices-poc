Feature: Dashboard Admin Service End-to-End

  Background:
    Given an authenticated admin user with a valid JWT token

  Scenario: View system-wide sales dashboard
    When the admin requests GET /api/reports/sales for the last month
    Then the response status should be 200 OK
    And the response should contain total sales, sales by product, and sales by agent
    And the response should include chart data for visualization

  Scenario: Export sales report as CSV
    When the admin requests GET /api/reports/sales/export with format "csv"
    Then the response status should be 200 OK
    And the response should contain a downloadable CSV file

  Scenario: View agent performance report
    When the admin requests GET /api/reports/agents for the last quarter
    Then the response status should be 200 OK
    And the response should list agents with their sales stats and trends

  Scenario: View product sales analytics
    When the admin requests GET /api/reports/products for the current year
    Then the response status should be 200 OK
    And the response should show sales per product and related charts

  Scenario: View payment and policy trend analysis
    When the admin requests GET /api/reports/trends for the last 6 months
    Then the response status should be 200 OK
    And the response should include payment status and policy lifecycle trends

  Scenario: Perform advanced search and bulk filter
    When the admin submits a POST to /api/reports/bulk/filter with filter criteria
    Then the response status should be 200 OK
    And the response should contain filtered sales aggregation results

  Scenario: Receive real-time sales updates
    When a new policy is created in the system
    Then the admin connected to SignalR SalesHub should receive a SalesUpdated notification

  Scenario: Check system health
    When the admin requests GET /api/health
    Then the response status should be 200 OK
    And the response should indicate healthy status for ElasticSearch, PolicyService, and PaymentService

  Scenario: Audit logging for admin actions
    When the admin exports a report
    Then an audit log entry should be created with the admin's username and action details

  Scenario: Access control enforcement
    When a non-admin user requests GET /api/reports/sales
    Then the response status should be 403 Forbidden
