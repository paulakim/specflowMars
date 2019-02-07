Feature: Task1_DoNotRun_TestCases
	In order to update my profile 
	As a skill trader
	I want to add the languages that I know

@AddSkill
Scenario Outline: Check if the seller is able to add new by clicking "Add" button in Skills after filling out all the details
Given I am on the Profile page.
When I click on Skills tab button.
And I click Add New button
And I have completed the form with <AddSkill> and <SkillLevel>.
And I click the Add button.
Then I should see the skill I have added.

Examples: 
| AddSkill | SkillLevel |
| Selenium | Expert     |

@AddEducation
Scenario Outline: Check if the seller is able to add new by clicking "Add" button in Education after filling out all the details
Given I am on the Profile page.
When I click on Education tab button.
And I click Add New button.
And I have completed the form with <NameCollUni> and <Country> and <Title> and <Degree> and <YearGraduation>.
And I click the Add button.
Then I should see the Education I have added.

Examples: 
| NameCollUni | Country     | Title | Degree   | YearGraduation |
| AIS         | New Zealand | B.A   | Software | 2016           |

@AddCertification
Scenario Outline: Check if the seller is able to add new by clicking "Add" button in Certification after filling out all the details
Given I am on the Profile page.
When I click on Certificaton tab button.
And I click Add New button.
And I have completed the form with <Certificate> and <CertifiedFrom> and <Year>.
And I click Add button.
Then I should see the Cerification I have added.

Examples: 
| Certificate | CertifiedFrom | Year |
| Excel       | MS            | 2017 |

@Availability
Scenario Outline: Check if the seller is able to change Availability by clicking small write icon
Given I am on the Pofile page.
When I click small write icon for Availability.
And I click <Time> of the list from drop down box.
Then I should see the updated Availability.

Examples: 
| Time    |
|Part Time|

@Hours
Scenario Outline: Check if the seller is able to change Hours by clicking small write icon
Given I am on the Profile page.
When I click small write icon for Hours.
And I click <Hours> of the list from drop down box.
Then I should see the updated Hours.

Examples: 
| Hours                  |
|Less than 30hours a week|

@EarnTarget
Scenario Outline: Check if the seller is able to change Earn Target by clicking small write icon
Given I am on the Profile page.
When I click small write icon for Earn Target.
And I click <EarnTarget>.
Then I should see the updated Earn Target.

Examples: 
| EarnTarget                       |
| Between $500 and $1000 per month |

@UpdateCertification
Scenario Outline: Check if the seller is able to update the information by clicking small write icon for Certification
Given I am on the Profile page.
When I click on Certificaton tab button.
And I click write small icon for Certification.
And I have changed with <Certificate> and <CertifiedFrom> and <Year>.
And I click Update button.
Then I should see the updated information for Cerification.

Examples: 
| Certificate | CertifiedFrom | Year |
| Testing     | ISTQB         | 2018 |

