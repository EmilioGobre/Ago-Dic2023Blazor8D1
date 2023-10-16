# Khe bergas es un monolito?

## Monolith

![Monolith](https://miro.medium.com/v2/resize:fit:1400/1*TRmj8lWyzCufEGjxCONAog.jpeg)

Monolith has everything in the same place, on the same release.

| Pros                     | Cons                       |
| ------------------------ | -------------------------- |
| > Efficient with < Views | Code Complex               |
| Divide and conquer       | Hard to Scale              |
| Reusable Code            | Break 1, Break All         |
| Only 1 to realese        | Slow to hold               |
| Only 1 thing to test     | End to end test is slow AF |
| Easy to find errors      | Hard to update             |
| Best for new Projects    |                            |

## Microservices

Containers Api
TDD:Test Driven Development

![Microservices](https://microservices.io/i/Microservice_Architecture.png)

- Kubernetes
- Orchestration
- Circuit Break

| Pros                           | Cons                                   |
| ------------------------------ | -------------------------------------- |
| Easy to scale                  | Hard to test                           |
| Mocularity                     | Hard to find errors                    |
| Each one compiles individually | Resources not used efficient           |
| Easy to divide and code        | Hard to integrate the complete project |
| Easy to Resionalize            | Curve of learning hard AF              |
|                                | Finding the error hurt                 |

## Escalabilidad

- Escalabilidad Horizontal
- Escalabilidad Vertical
