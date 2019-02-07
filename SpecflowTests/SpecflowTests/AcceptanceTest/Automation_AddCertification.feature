Feature: Automation_AddCertification
	In order to update my profile 
	As a skill trader
	I want to add the Certification that I know

@AddCertification
Scenario Outline: Check if the seller is able to add new by clicking "Add" button in Certification after filling out all the details
Given I am on Profile page.
When I click on Certificaton tab button.
And I click on Add New button.
And I complete the form with <Certificate> and <CertifiedFrom> and <Year>.
And I click Add button.
Then <Certificate> and <CertifiedFrom> and <Year> should be displayed on the list.

Examples: 
| Certificate | CertifiedFrom | Year |
| Excel       | MS            | 2017 |

