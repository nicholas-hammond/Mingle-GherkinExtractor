
Feature: 

Scenario Outline: Given I have made a booking 
When I change my < Firstname> to < NewFirstName>
And my <Secondname> to <NewSecondName>
Then I am not charged a Name change Fee

Examples: 
| First Name | NewFirstName | SecondName | NewSecondName     |               |
| Steve      | Steven       | Jackson    | Jackson           |               |
| Giörgos    | George       | De-metrios | Demetrios         | * Greek name  |
| Josephine  | Jozåfina     | Cooper     | Cooper            | * Polish name |
| Hariss     | Harrëson     | Owen       | Owen              |               |
| Chris      | Christopher  | Bridges    | Bridges           |               |
| Matt       | Matthew      | Jones      | Jones             |               |
| Steve      | Steïve       | Jackson    | Jack              |               |
| Dave       | Dave         | Peterson   | Pete              |               |
| John-Paul  | Jöhn-paul    | hamilton   | Hamilton-Bradshaw |               |
| Andy       | Andy         | Marek      | Mark              | * Polish name |
| Chris      | Chris        | Theödoros  | Theo              | * Greek name  |
| Matt       | Matthew      | JONes      | Jones-cambells    |               |
| Steve      | Stèvie       | Gold       | Goldsmith         |               |
| Dave       | Daved        | Peterson   | Pete              |               |
| Rafal      | Rafael       | Stefan     | Szczepan          | * Polish name |
| Demi       | Dèmetrios    | Theo       | Theödoros         | * Greek name  |
| Chris      | Christopher  | Bridges    | Bridgeswater      |               |
| Christian  | Chrïs        | Jönes      | Jones-cambells    |               |