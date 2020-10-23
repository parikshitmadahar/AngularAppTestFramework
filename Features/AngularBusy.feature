Feature: AngularBusy
	In order to test the angular busy application
	As an angular developer
	I want a page showing angular-busy functionality 

Scenario Outline: E2E covering Acceptance Critera #7
	Given User is on Angular busy app
	When User set minimum duration to '<Minimum Duration>' ms
	And User enters message '<message>' in textbox
	And clicks Demo button
	Then the busy indicator with message should be displayed
	Examples: 
	| Minimum Duration |	message			|
	|                  |				    |
	|	     		   |   Please Wait...   |
	|        		   |       Waiting      |
	|    1000		   |       Waiting      |


Scenario Outline: E2E test for all acceptance criteria
	Given User is on Angular busy app
	When User set minimum duration to '<Minimum Duration>' ms
	And User set delay value to '<Delay>' ms
	And User select template drop down as '<Template Url>'
	And User enters message '<message>' and clicks Demo button
	Then the busy indicator with message should be displayed
	Examples: 
	| Minimum Duration | message        | Delay | Template Url         |
	|                  | Please Wait... | 1000  | Standard             |
	|  1000            | Waiting        | 2000  | custom-template.html |
	|  1000            | Waiting        | 3000  | Standard             |
	|  15000           | Please Wait... | 10000  | custom-template.html |
	|  6000            | Please Wait... | 5000  | Standard             |

Scenario: AcceptanceCriteria#7 Sequential Tests on same window
	Given User is on Angular busy app
	When User enters message 'Please Wait...' and clicks Demo button
	Then the busy indicator with message should be displayed
	When User enters message 'Waiting' and clicks Demo button
	Then the busy indicator with message should be displayed
	When User set minimum duration to '1000' ms
	And clicks Demo button
	Then the busy indicator with message should be displayed

 Scenario: Failure tests1
	Given User is on Angular busy app
	When User set delay value to '4000' ms
	And User set minimum duration to '' ms
	And User select template drop down as 'Standard'
	And User enters message 'Please Wait...' and clicks Demo button
	Then the busy indicator with message doesnt display

Scenario: Failure tests2
	Given User is on Angular busy app
	When User set delay value to '5000' ms
	And User set minimum duration to '2000' ms
	And User select template drop down as 'custom-template.html'
	And clicks Demo button
	Then the busy indicator with message doesnt display

