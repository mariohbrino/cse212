The linked list would be a great data structure to handle stack and
queue because it works well on the front and the end of the list
with great performance by adding and removing from the head and tail
of the linked list.

1. Explain how you would use a linked list internally to
implement a Stack. Make sure to explain the way you would
use the linked list AND the time complexity associated with
each of the following operations:

- Push
- Pop
- GetTop
- IsEmpty

A: The linked list would have a head and tail. The basic opeartions like
add, get, and remove would happen on the tail. The list is empty if the
head or tail are null.

Push
To push an item it must be handled on the end or tail by creating a new
node, pointing the tail previous to the new node, and finally pointing
the tail to the new node. The time complexity is O(1).

Pop
To pop it must remove the item from the end or tail, where it requires
to point the previous of the tail to the second tail item and point the
next of the second tail to the tail. The time complexity is O(1).

GetTop
To get top it must use the tail since it points to the last item. The time
complexity is O(1).

IsEmpty
To check if the list is empty it can check if the head is empty, it's
also possible check for head and tail. The time complexity is O(1).

2. Explain how you would use a linked list internally to implement a
Queue. Make sure to explain the way you would use the linked list AND
the time complexity associated with each of the following operations:
- Enqueue
- Dequeue
- Size
- IsEmpty

A: The linked list would have a head and tail. The operations would be as
follow add to the tail, get from the head, and remove from the head. The
list is empty if the head or tail are null.

Enqueue
To enqueue an item it must be handled on the end or tail by creating a new
node, pointing the tail previous to the new node, and finally pointing
the tail to the new node. The time complexity is O(1).

Dequeue
To dequeue it must remove the item from the front or head, where it requires
to null the previous of the second head item and to point the next of the head
to the second front item. The time complexity is O(1).

Size
I think could add an property to increase or reduce the count when an item
is enqueued or dequeued. The time complexity is O(1).

Empty
To check if the list is empty it can check if the head is empty, it's
also possible check for head and tail. The time complexity is O(1).