
Scenario: Name correction allowed for free 

Given I have made a booking
When I make a name correction 
Then I am not charged a name change Fee

Scenario Outline: Confirmation of name correction

Given I have made a name correction 
When I navigate to <page> page 
Then updated name will be displayed

Examples:
|Pages              |
|Confirmation Page  |
|Confirmation Email | 
|Boarding Pass      | 

Scenario: Name Correction updated in eRes
Given I have made a name correction 
When I view my booking in eRes
Then this has been updated to with the change 
And Booking has been flagged as being corrected 

Scenario: Name Correction only allowed Once for Free 
Given I have made a booking 
And already made a name correction 
When I make another name correction 
Then I am charged the change Fee