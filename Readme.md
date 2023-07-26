# DND Character Sheet Webapp
This is a simple webapp that stores player's DnD characters in a database. It also stores weapons, items, and spells the player may create.

It's straight forward, the entire app can be accessed from the header bar links and the following pages should clearly state how to edit, create, or delete entries.

For project requirements the project has examples of:

> Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program

This is seen in the weapon and spell controllers, where a dictionary is made so that the results from a SQL query can be used to create a dice value like 2d8+3 etc.

> Make a generic class and use it

Almost every model is a generic class which is then used in conjuntion with SQL.

> Query your database using a raw SQL query, not EF

Same as the dictionary above.