# Insertion Sort

## Pseudo Code

```
  InsertionSort(int[] arr)
  
    FOR i = 1 to arr.length
    
      int j <-- i - 1
      int temp <-- arr[i]
      
      WHILE j >= 0 AND temp < arr[j]
        arr[j + 1] <-- arr[j]
        j <-- j - 1
        
      arr[j + 1] <-- temp
```

## Sample Input

```
[8,4,23,42,16,15]
```

## High Level Description

Insertion sort looks for an out of order value in an array, and when it finds one, employs an a nested loop to shift the elements of the array forward, filling in where the out of order value was, until it finds where the out of order value should be in an ordered array. Insertion sort then inserts the value in the appropriate index, finally proceeding onward through the array looking for more out of order values.

## Step-by-Step Walk-Through With Sample Input

We will be using a sample array of `[8,4,23,42,16,15]` for the following step-by-step walk-through of this algorithm. We will employ nested numbered lists to show the operations of the for and while loops.

- On our first pass through the outer for loop, we set i to 1 (the second index value), and j to 0 (i - 1). We then grab the value at index i in a temporary variable, temp, which will be used as a sort of seed value. For this first pass, temp is 4.
    1. The inner while loop is executed until either j >= 0 (recall the while loop works backwards through the array) OR temp (the value at index i) is less than the value at index j (to put it another way, until the while loop has shifted backwards through the array far enough that the seed value, temp, is greater than the current value at index j).
        1. For this first pass, 4 < arr[j], so we enter the while loop.
        1. The while loop performs one iteration, copying arr[j] to arr[j + 1], so we exit the while loop with our array as `[8,8,23,42,16,15]` and j = -1.
    1. Outside the while loop, but still within the for loop, we assign that seed value, temp (which is 4), to arr[j + 1], so arr[0]. This leaves the array as `[4,8,23,42,16,15]`

***

- Our second and third passes through the for loop are uneventful, as 23 is not less than 8, nor is 42 less than 24. The while loop remains uninitialized.

***

- Our fourth pass is where things get exciting! Here i = 4 and j = 3, and recall our array is still unchanged from the first pass, so `[4,8,23,42,16,15]`, so our temp is set to 16 (arr[i] = arr[4]).
    1. j is greater or equal to 0, satisfying the first condition of entering the while loop. Additionally, 16 is less than 42.
        1. On the first pass through the while loop, again arr[j] is copied to arr[j + 1], leaving us with the array `[4,8,23,42,42,15]`. j is decremented by 1, so j = 2.
        1. On the second pass, we shift one element to the left and perform the same operation, leaving us with `[4,8,23,23,42,15]` and j = 1.
        1. There is no third pass, as now arr[j] is 8, and so temp (16) is greater than arr[j].
    1. Upon exiting the while loop, but still within the for loop, we set arr[j + 1] to temp, so arr[2] = 16. This leaves us with `[4,8,16,23,42,15]`.

***

- The fifth and final pass will be quite similar to the fourth, only starting from a higher index and traversing deeper backwards through the array. Our array is `[4,8,16,23,42,15]`, i = 5 and j = 4, so temp is 15.
    1. 15 is less arr[j], which is 42, so we enter the while loop.
        1. Again, arr[j] is copied to arr[j + 1], and j is decremented by 1. This leaves us with `[4,8,16,23,42,42]` and j = 3.
        1. On the next pass, we are left with `[4,8,16,23,23,42]` and j = 2.
        1. Again, and we have `[4,8,16,16,23,42]` and j = 1.
        1. No fourth while loop iteration, as now arr[j] (arr[1]) is 8, and 8 < temp (15).
    1. Now upon exiting the while loop, we insert temp at arr[j + 1], leaving us with `[4,8,15,16,23,42]`.
    1. i is now equal to arr.length, so we exit the outer for loop, our array sorted in-place.