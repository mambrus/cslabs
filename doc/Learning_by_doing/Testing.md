# Learning by doing **Automated testing**

## Plan / work

- [x] Set-up and run a simple test for a simple application from scratch

## References

* [NUnit Quick Start](https://www.nunit.org/index.php?p=quickStart&r=2.6.4)
* [NUnit attributes](https://github.com/nunit/docs/wiki/Attributes)

### Tutorials & Labs

# Notes

## 2017-03-28

Three `Attributes` are needed

* `[TestFixture]`
* `[SetUp]`
* `[Test]`

`NUnitQuickStart` uses yet another (`[ExpectedException(<Type>]`), but
nothe this is obsolete in later versions of NUnit.

### To run

Either:

* Right-click project, then select `"Run Unit Tests"`
* Key-combo `<C>-u, <C>-r`
* `nunit-console ./bin/Debug/NUnitQuickStart.exe`
* Click on a green dot in the code (look for `[Test]` attributes)

