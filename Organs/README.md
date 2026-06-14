# Organs System

Organs system simulates every special organs, which are listed
in the `enum` in the OrgameNames.cs file.

## Organ Overview

Organ plays their role in maintaining homeostasis inside body.

Each organ have a board with all its signals. Organ
communicate with homeostasis with its own signals boards.

## Organ States and Pathology

Organ has six states, they are `Healthy`, `Insufficient`, `Damaged`,
`Unknown`, `Dead` and `Lost`.

If an organ is ill or damaged, then the organ set a bit of pathology
to 1. See `OrganPathology` for more information.

## More About Each Organ

### Brain

Has six parts, including brain stem, cerebellum, cerebrum, diencephalon,
limbic system and meninges. Each part has smaller tissue. All owns health 
value.