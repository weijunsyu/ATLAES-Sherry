# MapleHunter2D
2D platforming/dungeon crawler; Monster Hunter game with Maplestory aesthetics

Visual Guides: (Definitions can be found in the document "Visual Asset Guidelines and Framework" (VAGF) on Google Drive)
  UNITY UNIT (henceforth referred to as simply unit) shall be equal to 128 linear pixels of which 1 placed in a square will be used as 1 GRID UNIT
  GRID UNIT (henceforth referred to as simply gridUnit) shall be equal to the unit that our artists will base work on (to enable a screen grid of 16x9)
  GAME UNIT (henceforth referred to as simply gameUnit) shall be equal to 0.25 the area of a gridUnit which is equal to 1 GAME TILE (defined in the VAGF)

  CANVAS SIZE = CAMERA SIZE = 16units by 9units = 2048px by 1152px
  UNITY UNIT = GRID UNIT = GRID TILE = 128px by 128px
  GAME UNIT = GAME TILE = 64px by 64px

  ALL UNITY BASED WORK WILL BE REFERENCED BY UNITY UNITS (as that's how unity works)

  CAMERA AND CANVAS REFERENCE:
    Size in pixels: 2048 by 1152

  Game Camera:
    Size: 4.5 units
    Length (width): 16 units
    Height: 9 units

  Static UI Canvas (Menus): (Use for menu screens that are not overlays such as the main menu screen)
    Pos X: 8
    Pos Y: 4.5
    Width: 2048
    Height: 1152
    Scale X: 0.0078125
    Scale Y: 0.0078125
    Dynamic Pixels Per Unit: 1
    Reference Pixels Per Unit: 1
