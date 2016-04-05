# FindMyPast.Test
Recruitment Test for Find My Past

My working solution is a simple MVC website, which consumes a table generator.
To run it just ensure that:
1. Set as StartUp Project 'FindMyPast.PrimeNumberTable.Website'
2. Set the Web Start Action to Specific Page: 'Default/Index'

I'm pleased with:
1. The code is clean.
2. By testing from the Outside-In it should feel well documented, and the API should seem quite intuitive.
3. Decoupling the prime number validator allowed me to focus on building the table.
4. Implementing the prime number validator was easy once I'd decoupled.
5. Consuming this into a website was very straight forward.

Given more time I would like to have:
1. On reflection I think my Prime Number Validator might not be quite what you were after. I've separated out generating the table and validating the factors. I like this separation of concerns personally, but I could have tried to design with a proper Prime Number Generator.
2. Performance - there are various documented rules that I could have built into the validating algorithm.
3. Performance - I could have persisted discovered prime numbers to prevent repeated loops where the user tries to generate several tables (the PrimeNumberValidator could have been instantiated by the web app and injected into the DefaultController as a single instance, perhaps with Autofac)
4. I could have used TDD to ensure my TableModel was mapping correctly - I got carried away coding and fortunately didn't make a mess!
5. My TableModel is possibly too complex with the mapping code.
6. I prefer to use Pair Programming to validate my approach to the problem, code cleanliness, and validating some design decisions.
