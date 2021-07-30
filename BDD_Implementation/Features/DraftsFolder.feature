Feature: DraftsFolder
	As a user
	I want to be able to create draft email
    And I want to be able to send draft emails

Background:
    Given I logged in to the system with login 'atmmodule6' and password 'AOyOJs1yoy1*'
    And I open create new email form
    And I fille the Recipient, Subject and Body fileds with values 'gevs--88@mail.ru', 'Test' and 'Test case creation for ATM Module 11'
    And I click on Save button
    And I close new email form
    And I open Drafts folder

Scenario: Test the creation of draft email
    When I open the first email from the lsit
    Then I see the Recipient, Subject and Body values eqaul to 'gevs--88@mail.ru', 'Test' and 'Test case creation for ATM Module 11'

Scenario: Test drafts folder after sending an email
    When I open the first email from the lsit
    And I send the email
    And I close the opened window after sending the email
    Then I don't see that email in drafts folder