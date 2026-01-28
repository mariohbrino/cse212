
- Your overall approach.
- Step-by-step discussion of how the function would behave.
- The Big O performance of your approach.
- Highlight at least 3 test cases that you would try to make sure your approach would work.

1. Describe how you would write a function to find the intersection of two sets. Your solution should NOT use
the built-in intersection method.

A. It would require to create another set that we will call result set. Then, loop through one set and check if the element
exist on the other set, when checking set's the performance is O(1), in case the element from first set is present on the
second set then add to the result set. The performance would be consider O(n) because the sets can contain different amount
of elements.

- Sets with equal elements would return a mirror set
- Sets with few different elements would return elements that were present on both sets
- Sets with all different elements would return empty

2. Describe how you would write a function to find the union of two sets. Your solution should NOT use the built-in union method.

A. I would require to create another set that reseaves the elements of both, this can loop through each set at time like a serial
for loop. The performance would be consider O(n + m) because the sets can contain different amount of elements.

- Sets with equal elements would return the same elements
- Sets with few different elements returns all elements between the sets
- Sets with all different elements would return all elements