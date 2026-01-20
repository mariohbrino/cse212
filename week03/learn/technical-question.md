Scenario: write code to find the first time in a string when a letter is duplicated.

1. What are possible scenarios to consider? (For example, think of a few strings that you would want to try with your solution.)
- I think could start with a string with a simple word like summary.

2. What are some data structures that may be useful? And what would their performance be?
- I think can be used a list to store the letters and a hash set to store the letters

3. What are the boundary conditions that you should consider for this problem?
- In case a letter exists on the hash set then stop the loop

4. Outline a possible solution.
- Using a list and a hash set it's possible to define the first duplicated by looping
the list of letters and stopping on the first existing letter. By using this approach
the performace should by O(1) when find the duplicated and O(n) in case there is no
duplicates.
