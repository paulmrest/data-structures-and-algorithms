# Challenge 30: Hash Table

A .NET Core class library that implements a HashTable class, and a KeyValueNode class to be used in the HashTable objects. Keys are strings, while values are generic <T>.

- `Add(string key, T value)`: adds a new key-value pair to the HashTable. Presently, this does not dynamically resize the HashTable, so a very large HashTable would end up being deep, and therefor not efficient.

- `Get(string key)`: returns a value for the corresponding key. If key is not present, returns default for the type. Note that default for some value-types can result in values that seem potentially correct. For example, a HashTable<int> would return 0 when Get() was invoked with a non-present key.

- `Contains(string key)`: returns a bool indicating whether a given key is present in the HashTable.

- `GetHash(string key)`: returns a hash value that will be > 0 and < HashTable.Length - 1. The same key will always generate the same hash value.

## Approach & Efficiency

- `Add(string key, T value)`:
    - Time:
        - Worst Case: O(n)
        - Best Case: O(1)
    - Space: O(1)

- `Get(string key)`:
    - Time:
        - Worst Case: O(n)
        - Best Case: O(1)
    - Space: O(1)

- `Contains(string key)`:
    - Time:
        - Worst Case: O(n)
        - Best Case: O(1)
    - Space: O(1)

- `GetHash(string key)`:
    - Time: O(1)
    - Space: O(1)

## Link(s) to Code

- [HashTable.cs](HashTables/Classes/HashTable.cs)
- [KeyValueNode.cs](HashTables/Classes/KeyValueNode.cs)

## Change Log

### 2020-08-16

- Improved implementation. HashMap now auto-resizes and has a Count property that reflects the current number of elements in the HashTable.

### 2020-08-16

- Initial implementation and tests.