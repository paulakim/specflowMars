Feature: Automation_AddEducation
	In order to update my profile 
	As a skill trader
	I want to add the Education that I know

@AddEducation
Scenario Outline: Check if the seller is able to add new by clicking "Add" button in Education after filling out all the details
Given I am on the Profile page.
When I click on Education tab button.
And I click Add New button.
And I enter <NameCollUni> and <Country> and <Title> and <Degree> and <YearGraduation> in the form for Education.
And I click the Add button.
Then I should see the Education I have added.

Examples: 
| NameCollUni | Country     | Title | Degree   | YearGraduation |
| AIS         | New Zealand | B.A   | Software | 2016           |

