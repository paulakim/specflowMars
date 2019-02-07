Feature: Automation_EditSkills
	In order to update my profile 
	As a skill trader
	I want to edit skill

@UpdateSkill
Scenario Outline: Check if the seller is able to update the information by clicking small write icon for Skills
Given I am on profile page.
When I click on Skills tab button.
And I click Add New button
And I have completed the form with <Skill> and <SkillLevel>.
And I click on Add button.
Then I should see <Skill> and <SkillLevel>.
When I click write small icon for Skills.
And I have changed with <UpdatedSkill> and <UpdatedLevel>.
And I click Update button.
Then <UpdatedSkill> and <UpdatedLevel> should be updated.

Examples: 
| Skill   | SkillLevel   | UpdatedSkill | UpdatedLevel |
| English | Intermediate | Korean       | Expert       |

