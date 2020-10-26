# PostOfficeManager

This repository represents my approach in the implementation of Post Office Manager with the 
requirements described below ([Task](#task)). I spent roughly around 2 hours on the implementation 
and managed to cover only three steps.

[Assumptions](#assumptions) | [Approach](#approach) | [Task](#task) | [Example](#example)

## Assumptions

Taking into account that this is not a real project but rather coding exercise, I made several 
assumptions which simplified the task. However, in a real-world project, those assumptions would
be addressed separately.

- Parcel dimensions are by default in centimetres and can be presented only as integers.
- Parcel weight is by default in kilos and can be presented only as integers.
- Currency is not set. We assume that we operate in the same currency and if we decide to localize the
the system, we will need to introduce converters.
- I assume that I use not the best terminology as I am not closely familiar with the domain knowledge of 
post offices. Naming is hard.

## Approach

I tried to build the system as modular as I could. I understand that in such simplistic exercise it can be 
overkill, but I assume that the goal of the exercise was to try to reflect real-life project with changing 
requirements. The loosely coupled system simplifies refactoring and changes in the system on later stages. 
Also, it makes testing of the system a much simpler task.

I cannot say that I am an expert in TDD but in this case, I tried to follow this approach and build unit tests
before the functionality. 

## Task

You work for a courier company and have been tasked with creating a code library to
calculate the cost of sending an order of parcels .

1) The initial implementation just needs to calculate cost based on a parcel’s size. For each
size category there is a fixed delivery cost
 - Small parcel: all dimensions < 10cm. Cost $3
 - Medium parcel: all dimensions < 50cm. Cost $8
 - Large parcel: all dimensions < 100cm. Cost $15
 - XL parcel: any dimension >= 100cm. Cost $25
2) Thanks to logistics improvements we can deliver parcels faster. This means we can
charge more money. Speedy shipping can be selected by the user to take advantage of our
improvements.
 - Speedy shipping doubles the cost of the entire order
 - Speedy shipping should be listed as a separate item in the output, with its
associated cost
 - Speedy shipping should not impact the price of individual parcels, i.e. their
individual cost should remain the same as it was before
3) There have been complaints from delivery drivers that people are taking advantage of
our dimension only shipping costs. A new weight limit has been added for each parcel type,
over which a charge per kg applies
+$2/kg over weight limit for parcel size:
 - Small parcel: 1kg
 - Medium parcel: 3kg
 - Large parcel: 6kg
 - XL parcel: 10kg
4) Some of the extra weight charges for certain goods were excessive. A new parcel type
has been added to try and address overweight parcels
Heavy parcel, $50 up to 50kg +$1/kg over 50kg
5) In order to award those who send multiple parcels, special discounts have been
introduced.
 - Small parcel mania! Every 4th small parcel in an order is free!
 - Medium parcel mania! Every 3rd medium parcel in an order is free!
 - Mixed parcel mania! Every 5th parcel in an order is free!
 - Each parcel can only be used in a discount once
 - Within each discount, the cheapest parcel is the free one
 - The combination of discounts which saves the most money should be selected
every time

## Example

6x medium parcels. 3x $8, 3 x $10. 1st discount should include all 3 $8 parcels and save $8.
2nd discount should include all 3 $10 parcels and save $10.
 - Just like speedy shipping, discounts should be listed as a separate item in the
output, with associated saving, e.g. “-$2”
 - Discounts should not impact the price of individual parcels, i.e. their individual cost
should remain the same as it was before
 - Speedy shipping applies after discounts are taken into account
