# Design Patterns

Something approved to solve an SPECIFIC problem.

## Anti Design-Patterns

God-Class: Una clase que hace todo.

### How to fix the god-class?

Separate responsabilities and distribute them to multiple classes instead of only one.

### Code Smells

Code Smells is an indicator of a possible problem. It point the area of your design that could benefit from a redesign.

#### Code Smell - Control Freak

An excellent example of a code smell is when you use the new keyword. This is an indicator of a harcoded dependency where the creator controls the new object and its life time.

#### Code Smell - Long Methods

The long methods code smell is when a method starts to extend to more than 10 or 15 lines of code.

##### Examples

- The method contains complex logic interwined in multiple condition statements.
- The method contains big switch blocks.
- The method contains too many things.
- The method contains duplication of code.

##### Fix it

- Extract one or more private methods.
- Estract some code to new classes.
- If you have a lot of conditionals statements or a huge switch block, you should use a design pattern called chain of resonsibility or CORS.
