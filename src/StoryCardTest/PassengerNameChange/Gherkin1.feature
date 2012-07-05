

Scenario Outline: Free Name changes 
Given my name is <FirstName> <SecondName>
When I change my name to < NewFirstName> <NewSecondName>
Then I am not charged a Name change Fee

Examples: 
|FirstName | NewFirstName | SecondName | NewSecondName     |
|Steve     | Steven       | Jackson    | Jackson           |
|Giörgos    | Geôrge       | Dïmetrios  | Demetrios         |
|Josèphine  | Jozefina     | Cooper     | Còöper            |
|Hariss     | Harrison     | Owèn       | Owen              |
|Chris      | Christopher  | Bridges    | Bridges           |
|Matt       | Matthew      | Jones      | Jones             |
|Steve     | Steve        | Jackson    | Jack              |
|Dave       | Dave         | Peterson   | Pete              |
|John-Paul  | Jöhn-paul    | hamilton   | Hamilton-Bradshaw |
|Andy       | Andy         | Marek      | Mark              |
|Chris      | Chris        | Theodoros  | Theo              |
|Matt       | Matthew      | Jones      | Jones-cambells    |
|Stève     | Steve        | Gold       | Göldsmith         |
|Davè       | Daved        | Petèrson   | Pètè              |
|Rafal      | Rafaèl       | Stèfan     | Szczepan          |
|Demi       | Demetriös    | Theö       | Theodoros         |
|Chrìs      | Christopher  | Bridges    | Brìdgeswater      |
|Christian  | Chrìs        | Jônes      | Jones-cambèlls    |



Scenario Outline: Paid for Name changes 
Given my name is <FirstName> <SecondName>
When I change my name to <NewFirstName> <NewSecondName>
Then I am charged a Name change Fee

Examples:
|FirstName | NewFirstName | SecondName | NewSecondName     |
|Stève     | Jack         | Jackson    | Jacksön           |
|Dave       | Jones        | Smith      | Smith             |
|David      | Dough        | Cooper     | Cooper            |
|Andi       | Aleksander   | Owïn       | öwen              |
|Steve     | Steeve    | Smith      | Jack              |
|Dave       | Dave         | Killens    | Bill              |
|John-Paul  | John-paul    | Booth      | Day               |
|Andy       | Andy         | Howells    | Harrison          |
|Chris      | Chris        | Farid      | Ford              |
|Môtt       | Matt         | MacMahôn   | McDonald          |
|Steve     | Stefan    | Gold       | George            |
|John-Paul  | Jermainel    | Coöper     | Corrôl            |
|Rafal      | ErÄk         | Stefan     | VonDutch          |
|Christian  | Nikita       | Jones      | Lewìs             |