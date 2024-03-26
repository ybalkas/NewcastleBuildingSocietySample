Feature: Book an Appointment on Newcastle Building Society Website

  As a potential customer
  I want to book an appointment online
  So that I can discuss financial services with a consultant

  Background:
    Given I am on the homepage of "https://www.newcastle.co.uk/"

  Scenario: Booking a financial consultation appointment
    When I navigate to the "Book an appointment" by cliking our branches
    And I click book an appointment
    Then Ishould be able to navigate "https://www.newcastle.co.uk/our-branches/book-an-appointment"
    And I enter my personal details including "Name", "Email", and "Phone number" etc..
      | Field     | Value                      |
      | FirstName | Yusufxy                    |
      | Surname   | Yusuf's Tech Solutions Ltd |
      | Phone     | 07645764438                 |  
      | Email     | ybalkeas@gmail.com         |
      | CallTime  | on Tuesday                 |

    When I click on the "Submit" button to book the appointment
    Then  I should be able to create an appointment
    