# Week 01 Interview Questions

- Video of up to 3 minutes.

1. What is an advantage of dynamic arrays compared to traditional, static arrays?

The advantage of the dynamic array is a flexible strucure that allows the array to perform with
the behavior that extend and at some point shrink, on the other hand a static array is defined
with a given scope that defines the rules that basically define the capacity and size that
cannot be changed. The structure is defined as a fixed array internally given the base features
of an static array and increases when capacity hit's the limit by double of the current capacity
and copying to a new allocated memory to avoid memory overflow.

2. What is a disadvantage of dynamic arrays compared to traditional, static arrays?

Dynamic arrays expand causing slow allocation by coping over elements to a new memory location
after capacity hits it's limit, and consume more memory due to extra metadata stored. On the other
hand static arrays is efficient and fast because the memory has less metadata stored and normally
it's designed to handle specific tasks due to it's constraints.
