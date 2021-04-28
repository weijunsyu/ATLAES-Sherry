# ATLAES: Sherry
2D platforming/dungeon crawler hybrid fighting game; Mono-chromatic, 2-bit black and white aesthetic with red "Blood" accents. [COLOUR: Hex (R, G, B, Alpha)]
      BLACK: 141414 (20,20,20,1), WHITE: FCFCFC (252,252,252,1), RED: D00000 (208,0,0,1)
  UI Colours:
      BLACK: 141414, WHITE: FCFCFC, RED: D00000, BLUE: 00D1D1 (0,209,209,1), YELLOW: F1D302 (241,211,2,1)

Visual Guides: (Definitions can be found in the document "Visual Asset Guidelines and Framework" (VAGF) on Google Drive)
  UNITY UNIT (henceforth referred to as simply unit) shall be equal to 64 linear pixels of which 1 placed in a square will be used as 1 GRID UNIT
  GRID UNIT (henceforth referred to as simply gridUnit) shall be equal to the unit that our artists will base work on (to enable a screen grid of 16x9)
  GAME UNIT (henceforth referred to as simply gameUnit) shall be equal to 0.25 the area of a gridUnit which is equal to 1 GAME TILE (defined in the VAGF)

  CANVAS SIZE = CAMERA SIZE = 16units by 9units = 1024px by 576px
  UNITY UNIT = GRID UNIT = GRID TILE = 64px by 64px
  GAME UNIT = GAME TILE = 32px by 32px

Artwork:
  Environment and World:
    All environment and world details will be constructed from GAME TILES or GAME UNITS (32px by 32px tiles).
    These tiles will ONLY be made up of 2 colours BLACK AND WHITE as defined above.
    WHITE will be the foreground and BLACK the background such that the skybox in the game will be BLACK.
    Objects that are larger than 1 GAME TILE can be made up of multiple tiles which will be reconstructed in Unity.

  Particles and Effects:
    Made on a 3x3 GAME TILE such that each tile will be 96px by 96px large.
    PARTICLES MUST EXIST INSIDE THIS TILE AND CANNOT EXTEND BEYOND THE BOUNDS OF ONE TILE. That is to say composite sprites cannot be used.
    Colours MUST be RED with a few exceptions made for WHITE to provide contrast and/or detail. RED should be the primary colour.

  Player Character and Humanoid NPCs:
    Made on a 3x3 GAME TILE such that each tile will be 96px by 96px large.
    Player character sprites have already been made, follow those examples and scale others accordingly.
    For reference the player character is a female adult.
    Player character will be made up of a WHITE foreground with RED accents and background.
    NPC characters will be WHITE foreground and BLACK background.

  Special NPC/Bosses:
    Made on a NxN GAME TILE such that N can be any positive integer.
    Similar to NPC designs, scale based on the player character sprite size and keep the colours WHITE and BLACK.

  NOTES ON COLOUR:
    All sprites should be made up of 2 colours only.
    Testing with colour swaps may occur but to maintain style ALL sprites MUST ONLY have TWO colours.


  ALL UNITY BASED WORK WILL BE REFERENCED BY UNITY UNITS (as that's how unity works)

  CAMERA AND CANVAS REFERENCE:
    Size in pixels: 1024 by 576

  Static UI Canvas (Menus): (Use for menu screens that are not overlays such as the main menu screen)
    Pos X: 8
    Pos Y: 4.5
    Width: 1024
    Height: 576
    Scale X: 0.015625
    Scale Y: 0.015625
    Dynamic Pixels Per Unit: 1
    Reference Pixels Per Unit: 1

  Dynamic UI Canvas (Pause, etc.): (Use for overlay screens such as pause menu screen)
  Keep everything at default (Scale = 1, etc.)
  MATCH the pixels per unit! (64)
