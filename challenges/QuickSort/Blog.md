# Quick Sort

## Pseudo Code

```
ALGORITHM QuickSortPublic(arr)
    QuickSort(arr, 0, arr.length - 1)

ALGORITHM QuickSort(arr, left, right)
    if left < right
        // Partition the array by setting the position of the pivot value 
        DEFINE position <-- Partition(arr, left, right)
        // Sort the left
        QuickSort(arr, left, position - 1)
        // Sort the right
        QuickSort(arr, position + 1, right)

ALGORITHM Partition(arr, left, right)
    // set a pivot value as a point of reference
    DEFINE pivot <-- arr[right]
    // create a variable to track the largest index of numbers lower than the defined pivot
    DEFINE low <-- left - 1
    for i <- left to right do
        if arr[i] <= pivot
            low++
            Swap(arr, i, low)

     // place the value of the pivot location in the middle.
     // all numbers smaller than the pivot are on the left, larger on the right. 
     Swap(arr, right, low + 1)
    // return the pivot index point
     return low + 1

ALGORITHM Swap(arr, i, low)
    DEFINE temp;
    temp <-- arr[i]
    arr[i] <-- arr[low]
    arr[low] <-- temp
```

## Sample Input

```
[8,4,23,42,16,15]
```

## High Level Description

The above code feels incomplete to me as it only contains the private helper methods, not the actual method that be available for invocation. So I'm adding to the above pseudo code the following:

```
ALGORITHM QuickSortPublic(arr)
    QuickSort(arr, 0, arr.length - 1)
```

Quick sort works by selecting a "pivot" and then shifting values less than that pivot to the left of it, and values greater than the pivot to the right. At each frame in the recursion, it bisects the array based off where that pivot ends up, as we know everything to the left of the pivot is smaller than it, and everything to th right is larger, but we don't yet know whether the elements left and right are themselves ordered. So as the recursion continues, it works with smaller and smaller sections of the array, until we are working with individual elements or pairs of elements.

## Step-by-Step Walk-Through With Sample Input

This is another cursive sort method, so describing it using the written word is somewhat challenging. That said, it sticks far better in my brain doing it this way than with pictures. So here we go:

For the step-by-step we can largely ignore the public method I added.

- Upon entering QuickSort at the lowest block in the recursion, we have an array of `[8,4,23,42,16,15]`. We've defined left and right the left-most and right-most index values, so `0` and `5`. Left is not less than right, so we clear the initial if statement.
- We invoke Partition and pass in the parameter array, and left, `0`, and right, `5`.
    1. Inside Partition, we define a variable `pivot` which we set to `arr[right]`. So `pivot = 15`
    1. We define a variable `low` (which should be called tracker...) and set it to left - 1. So `low = -1`.
    1. We enter a for loop that traverses the array from `left` to `right`.
        1. Inside the for loop, at each step we check if the for loop's current index value in the array is less than or equal to the value at `arr[pivot]`. Since we are starting at `0` with the for loop, in this first iteration, are checking `arr[0]`, which is `8`, against `15`. `8` is less than `15` so we increment `low` by `1`, so it is not `0`, and perform a swap. The swap just swaps the position of `i` and `low`, but since they are both `0`, our array is unchanged
        1. On the next iteration, `i` now being `1`, we are checking if `4` is less than `15`, and it is, so we increment `low` by `1` making it `1`, and perform a swap again. And again, `i` and `low` point at the same value, so nothing is changed.
        1. For our third iteration, `arr[2]` is `23`, which is not less than or equal to 15, so no further actions are performed.
        1. For our fourth iteration, `arr[3]` is `42`, so again, nothing is changed.
        1. For our fifth iteration, `arr[4]` is `16`, and again, nothing is changed.
    1. Outside the for loop, we do a swap on `right`, which is `5`, and `low + 1`, which is `2`. This leaves us with the array `[8,4,15,42,16,23]`.
    1. We return `low` plus `1`, so `2`.
- A variable, `position`, captures whe integer Partition returns, `2`.
- We recursively call QuickSort on the left, passing in the updated array, `[8,4,15,42,16,23]`, `left`, which is `0`, and `position` minus `1`, so `1`.
    - Entering QuickSort, `left` is `0`, and `right` is `1`.
    - We invoke Partition and, pass in the array `[8,4,15,42,16,23]`, and `left` and `right`.
        1. Inside this recursion's Partition, we set pivot to `arr[1]`, so `4`.
        1. We define a variable called `low` and set it to `left - 1`, so `-1`.
        1. We enter the for loop and traverse the array from `left` to `right`.
            1.  In the first and only iteration, we check if `arr[0]` is less than or equal to `pivot`. `arr[0]` is 8, which is not less than `pivot = 4`.
        1. Outside the for loop, we swap `arr[low + 1]`, `0` with `arr[right]`, `1`, leaving us with the array `[4,8,15,42,16,23]`
        1. We return `low + 1`, so `0`.
    - The variable `position` captures the value returned from Partition, `0`.
    - We recursively call QuickSort on the left side and pass in the array `[4,8,15,42,16,23]` and `left = 0` and `right = 0`, as `position - 1 = 0`.
        - Entering QuickSort, `left` is NOT less than `right`, so we exit with no further changes.
    - We recursively call QuickSort on the right side and pass in `left = 1` and `right = 1`.
        - Entering QuickSort, `left` is NOT less than `right`, so we exit with no further changes.
- We recursively call QuickSort on the right, passing in the array `[4,8,15,42,16,23]` and `left = 3` and `right = 5`.
    - Entering QuickSort, we invoke Partition with `left = 3` and `right = 5`.
        1. Inside Partition, `pivot` is set to `23`, as `arr[5] = 23`, and `low` is `2`, as `left - 1 = 2`.
        1. We enter the for loop to traverse from `left` to `right`.
            1. In the initial iteration, we check if `arr[3]`, `42`, is less than or equal to `23`. It's not.
            1. In the second iteration, we check if `arr[4]`, `16`, is less than or equal to `23`. It is, so we increment `low` to `3` and call swap. This leaves us with the array `[4,8,15,16,42,23]`.
        1. Exiting the for loop, we swap `arr[right]` with `arr[low + 1]`, so `arr[5]` with `arr[4]`. This leaves us with `[4,8,15,16,23,42]`.
        1. We return `low + 1`, so `4`.
    - We capture Partition's return value in a variable `position`,.
    - We recursively call QuickSort on the left, with `left = 3` and `right = 3`, or `right = position - 1`.
        - Entering QuickSort, `left` is NOT less than `right`, so we exit with no further changes.
    - We recursively call QuickSort on the right, with `left = position + 1`, so `5`, and `right = 5`.
        - Entering QuickSort, `left` is NOT less than `right`, so we exit with no further changes.
- Array is now sorted.