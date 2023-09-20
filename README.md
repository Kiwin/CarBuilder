# CarBuilderWebApp

To be, a car designer/builder where car parts have performance improving stats.

# Model

![model](Docs/images/model.png)

```mermaid
erDiagram
    CarPart }|--|| CarPartCategory : has-many

    CarBuild }|--|{ CarPart : has-many
```

# Major Features

- [ ] Car build optimizer: Generate the best performing car build for a user specified stat.
