# cse212-ww-student-template
This is the starting repository for student work for CSE 212 at BYU-Idaho. It should be
used as a template repository for each student to start their own repo.

# Permissions to use
This code is used for class assignments for CSE 212 at Brigham Young University-Idaho.
Copying this code is a violation of the BYU-Idaho Honor Code.

To ensure that you are learning the concepts of the course, any code that you add to this
starter template should be your own work. If you have any questions about this, ask your
teacher.

## Running Test Cases

It appears that I cannot run class test cases directly in Visual Studio. Instead, I use the
command line to run the tests.

To run all test cases for a specific folder, use the following command:
```bash
dotnet test week03/code -l "console;verbosity=normal"
```

To run only the test cases for a specific test case use a filter like the `FindPairs` method.
```bash
dotnet test week03/code --filter Name~FindPairs_ -l "console;verbosity=normal"
```
