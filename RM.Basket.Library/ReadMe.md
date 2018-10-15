# Test Demo Apply Discounts to Basket
Developer: RIchard Mohammed
Status: Work in progress

This demo can be used to view the application of specified discounts to a shopping basket's total when the 
update total method is called. 

The current rules are:
• Buy 2 Butter and get a Bread at 50% off
• Buy 3 Milk and get the 4th milk for free

where the prices are as follows:
• Butter £0.80
• Milk £1.15
• Bread £1.00

There are various updates needed such as the ability to have a user login and create 
a basket relevelant to that user as well as updating the basket to enable changing of the quantities of products inside the basket.
It currently has a fixed basket id and assumes the main feature under test is the ability to calculate the correct applicable discount.
The UI is also in dire need of updating but I assume this is not currently a major factor in this test.

# Usage
Once downloaded, please build the project.
The Unit Test and Integration Tests (which uses an in-memory database) can be run immediately.
To run the MVC application however an SQL database needs to be created by EF. 
To do so, please run **update-database** in the package manager console in order to create the 
database (and seed data) from the Migrations.
