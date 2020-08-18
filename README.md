# MapleHunter2D
2D platforming/dungeon crawler; Mono-chromatic, 1-bit black and white aesthetic with red "Blood" accents.
      BLACK: 141414, WHITE: FCFCFC, RED: D00000
  UI Colours:
      BLACK: 141414, WHITE: FCFCFC, RED: D00000, BLUE: 00D1D1, YELLOW: F1D302

Visual Guides: (Definitions can be found in the document "Visual Asset Guidelines and Framework" (VAGF) on Google Drive)
  UNITY UNIT (henceforth referred to as simply unit) shall be equal to 64 linear pixels of which 1 placed in a square will be used as 1 GRID UNIT
  GRID UNIT (henceforth referred to as simply gridUnit) shall be equal to the unit that our artists will base work on (to enable a screen grid of 16x9)
  GAME UNIT (henceforth referred to as simply gameUnit) shall be equal to 0.25 the area of a gridUnit which is equal to 1 GAME TILE (defined in the VAGF)

  CANVAS SIZE = CAMERA SIZE = 16units by 9units = 1024px by 576px
  UNITY UNIT = GRID UNIT = GRID TILE = 64px by 64px
  GAME UNIT = GAME TILE = 32px by 32px

  ALL UNITY BASED WORK WILL BE REFERENCED BY UNITY UNITS (as that's how unity works)

  CAMERA AND CANVAS REFERENCE:
    Size in pixels: 1024 by 576

  Game Camera:
    Size: 4.5 units
    Length (width): 16 units
    Height: 9 units

  Static UI Canvas (Menus): (Use for menu screens that are not overlays such as the main menu screen)
    Pos X: 8
    Pos Y: 4.5
    Width: 1024
    Height: 576
    Scale X: 0.015625
    Scale Y: 0.015625
    Dynamic Pixels Per Unit: 1
    Reference Pixels Per Unit: 1
