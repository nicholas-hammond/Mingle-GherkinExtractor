

Feature: Addition
 In order to avoid silly mistakes because of my wife being mad with me
 As a math idiot
 I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
 Given I have entered 60 into the calculator
 And I have entered 70 into the calculator
 When I press add
 Then the result should be 130 on the screen