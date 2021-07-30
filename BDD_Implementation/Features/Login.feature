Feature: Login
	As a user
	I want to be abel to login with correct credentilas and logout
    And I want not to be able to login with incorrect credentials

Scenario: Test login with correct credentilas
    When I enter 'atmmodule6' to the login field
    And I click on Enter Password Button
    And I enter 'AOyOJs1yoy1*' to the password field
    And I click on Enter button
    Then I see the user with 'atmmodule6' is successfully logged in

Scenario: Test logout from the system
    When I login to the system with login 'atmmodule6' and password 'AOyOJs1yoy1*'
    And I open profile menu
    And I click on logout button
    Then I can logout from the system successgully

Scenario Outline: Test login with incorrect domain
    When I enter 'atmmodule6' to the login field
    And I select <domain>
    And I click on Enter Password Button
    Then I see 'Неверное имя ящика' error message

    Examples: 
    | domain      |
    | inbox.ru    |
    | list.ru     |
    | bk.ru       |
    | internet.ru |