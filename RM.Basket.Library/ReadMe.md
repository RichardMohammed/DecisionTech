# Test Demo Apply Discounts to Basket

Status: Work in progress

This demo can be used to see the application of specified discounts to a shopping basket's total when the 
update total method is called. There are various updates needed such as ability to have a user login and create 
a basket relevelant to that user as well as updating the basket to enable changing of the quantities.
It currently has a fixed basket id and assumes the main feature under test is the ability to calculate the correct discount.

# Note
You may need to run update-database in the package manager console in order to create the database from the Migrations