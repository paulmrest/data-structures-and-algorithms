# Merge Sort

## Pseudo Code

```
ALGORITHM Mergesort(arr)
    DECLARE n <-- arr.length
           
    if n > 1
      DECLARE mid <-- n/2
      DECLARE left <-- arr[0...mid]
      DECLARE right <-- arr[mid...n]
      // sort the left side
      Mergesort(left)
      // sort the right side
      Mergesort(right)
      // merge the sorted left and right sides together
      Merge(left, right, arr)

ALGORITHM Merge(left, right, arr)
    DECLARE i <-- 0
    DECLARE j <-- 0
    DECLARE k <-- 0

    while i < left.length && j < right.length
        if left[i] <= right[j]
            arr[k] <-- left[i]
            i <-- i + 1
        else
            arr[k] <-- right[j]
            j <-- j + 1
            
        k <-- k + 1

    if i = left.length
       set remaining entries in arr to remaining values in right
    else
       set remaining entries in arr to remaining values in left
```

## Sample Input

```
[8,4,23,42,16,15]
```

## High Level Description

Merge sort recursively bifurcates an array until it arrives at parts too small to sort, individual elements. Then it merges those bifurcated pieces, starting with the smallest sections first, sorting as it merges. Then it merges those sorted smallest sections back into sorted next-smallest sections, and so on, until we've reconstructed the entire original array, only sorted.

## Step-by-Step Walk-Through With Sample Input

Recursion can be challenging to describe using just words, as it feels like a lot of "and meanwhile back on the ranch...", but I'm going to give it a shot here.

Our sample input will be `[8,4,23,42,16,15]`.

- Upon entering Mergesort initially, we check if the array's length is > 1. The array's length is 6, so we carry on into the algorithm. We set a midpoint which will be 3, and then create a leftArray consisting of index 0 to 2, and a rightArray consisting of index 3 to 5. So leftArray is `[8,4,23]` and rightArray is `[42,16,15]`.
    
    1. We then recursively pass leftArray, `[8,4,23]`, to Mergesort.
        - Our parameter array's length is > 1, so we proceed. Midpoint is set to 1 (integer division of 3/2 is 1). leftArray is index 0 to 0, and rightArray will be index 1 to 2. So leftArray is `[8]` and rightArray is `[4,23]`.
            
            1. Again, we recursively pass leftArray, `[8]`, to Mergesort. The array's length is not > 1, so the algorithm just exits.
            
            1. More interestingly, we pass rightArray, `[4,23]`, to Mergesort, 
                - Here we set a midpoint of 1, and break the array into leftArray `[4]` and rightArray `[23]`.
                    
                    1. leftArray (`[4]`) is recursively passed to Mergesort, but as the array's length is not > 1, we just exit.
                    
                    1. rightArray (`[23]`) is recursively passed to Mergesort as well, and again, the length is not > 1, so we simply exit.
                
                - We pass our leftArray, `[4]`, rightArray, `[23]`, and our parameter array, `[4,23]`, to the Merge algorithm.
                    1. Merge puts the values from leftArray and rightArray back into the parameter array in the correct order, which in this case, means it ends with `[4,23]`.
                - This leaves our merged, sorted, array as `[4,23]`.

        - We exit the recursive calls of Mergesort with leftArray as `[8]` and rightArray as `[4,23]`.

        - We pass our leftArray, `[8]`, rightArray, `[4,23]`, and parameter array, `[8,4,23]` to the Merge algorithm. Merge builds out its merged, sorted, array in as follows:
            1. rightArray[0] is less than leftArray[0], so first we put rightArray[0] into our parameter array at index 0, leaving us with `[4,4,23]`.
            1. rightArray[1] is not less than leftArray[0], so we put leftArray[0] into our parameter array at index 1, leaving us with `[4,8,23]`.
            1. The tracker for our leftArray is now out of bounds, indicating that that array's elements have been used, so we exit the while loop and instead simply sequentially dump the not-yet-accessed elements from the non-exhausted array, rightArray, onto the parameter array. In this case, that is just rightArray[1], leaving our parameter array as `[4,8,23]`.
        - Our merged, and sorted array (recall the original was `[8,4,23]`) is `[4,8,23]`.

    1. We then recursively pass rightArray (`[42,16,15]`) to Mergesort.
        - Our parameter array's length is > 1, so we proceed. Midpoint is set to 1 (integer division of 3/2 is 1). leftArray is index 0 to 0, and rightArray will be index 1 to 2. So leftArray is `[42]` and rightArray is `[16,15]`.
            
            1. Again, we recursively pass leftArray (`[42]`) to Mergesort. The array's length is not > 1, so the algorithm just exits.
            
            1. More interestingly, we pass rightArray (`[16,15]`) to Mergesort, 
                - Here we set a midpoint of 1, and break the array into leftArray `[16]` and rightArray `[15]`.
                    
                    1. leftArray, `[16]`, is recursively passed to Mergesort, but as the array's length is not > 1, we just exit.
                    
                    1. rightArray, `[15]`, is recursively passed to Mergesort as well, and again, the length is not > 1, so we simply exit.
                
                - We pass our leftArray, `[16]`, rightArray, `[15]`, and our parameter array, `[16,15]`, to the Merge algorithm.
                    1. Merge puts the values from leftArray and rightArray back into the parameter array in the correct order, which in this case, means it ends with `[15,16]`.
                - This leaves our merged, sorted, array as `[15,16]`.

        - We exit the recursive calls of Mergesort with leftArray as `[42]` and rightArray as `[15,16]`.

        - We pass our leftArray, `[42]`, rightArray, `[15,16]`, and parameter array, `[42,16,15]` to the Merge algorithm. Merge builds out its merged, sorted, array in as follows:
            1. rightArray[0] is less than leftArray[0], so first we put rightArray[0] into our parameter array at index 0, leaving us with `[15,16,15]`.
            1. rightArray[1] is also less than leftArray[0], so we put rightArray[1] into our parameter array at index 1, giving us `[15,16,15]`.
            1. The tracker for our rightArray is now out of bounds, indicating that that array's elements have been used, so we exit the while loop and instead simply sequentially dump the not-yet-accessed elements from the non-exhausted array, leftArray, onto the parameter array. In this case, that is just leftArray[0], leaving our parameter array as `[15,16,42]`.
        - Our merged, and sorted array (recall the original was `[42,16,15]`) is `[15,16,42]`.

- Finally, we pass our leftArray, `[4,8,23]`, and rightArray, `[15,16,42]`, and our parameter array, `[8,4,23,42,16,15]`, to Merge, which builds the final, sorted, array, as follows:
    1. leftArray[0] is less than rightArray[0], so we copy leftArray[0] into the parameter array at index 0, giving us `[4,4,23,42,16,15]`.
    1. leftArray[1] is less than rightArray[0], so we copy leftArray[1] into the parameter array at index 1, giving us `[4,8,23,42,16,15]`.
    1. leftArray[2] is NOT less than rightArray[0], so we copy rightArray[0] into the parameter array at index 2, giving us `[4,8,15,42,16,15]`.
    1. leftArray[2] is NOT less than rightArray[1], so we copy rightArray[1] into the parameter array at index 3, giving us `[4,8,15,16,16,15]`.
    1. leftArray[2] is less than rightArray[2], so we copy leftArray[2] into the parameter array at index 4, giving us `[4,8,15,16,23,15]`.
    1. Now the tracker for leftArray is out of bounds, so we've used all the elements from that array. We move onto sequentially dumping the elements from rightArray into our parameter array (which again, is just rightArray[2]), leaving us with `[4,8,15,16,23,42]`.
- Our final, merged, sorted, array is `[4,8,15,16,23,42]`.