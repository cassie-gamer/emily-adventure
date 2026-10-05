# Emily's Adventure — Find Ava and Mom & Dad

A cute 3D adventure based on Emily's story. You play as little Emily, following twinkly fireflies to find her big sister Ava in the cave behind the waterfall, then together finding Mommy and Daddy in the dark forest — while tigers and snakes roam! At the end a rescue ship takes the whole family home. VICTORY!

## Story

Hi! I'm Emily! After our giant ship sank in a storm, me, my big sister Ava, and Mommy and Daddy lived in a hut in the forest. Then Mommy and Daddy went to find food and never came back. Ava climbed the tall rock to light a signal fire but got stuck in a cave behind the waterfall. Now it's up to you (as Emily) to find them all!

## How to play

1. **Watch the intro**: the ship sails, the storm comes, the ship sinks... then you wake up at the forest hut!
2. **Find Ava**: follow the glowing fireflies to the waterfall cave. Touch Ava to rescue her — she'll follow you!
3. **Dodge dangers**: a tiger and snakes chase Emily! Outrun them, or wave your **fire stick (F key)** to stun them for a few seconds (it needs to recharge). If one touches you, you lose courage — lose it all and you run back to the hut!
4. **Find the clues**: with Ava following, touch 3 clues (Daddy's hat, Mommy's scarf, footprints).
5. **The rescue**: Mom and Dad appear! Touch them, and a rescue ship sails in to take the whole family home. VICTORY!

## Setup (Windows, Unity)

1. Install Unity Hub + latest LTS with Windows Build Support
2. Create a new **3D (Core)** project called `EmilysAdventure`
3. Copy all `.cs` files from `Assets/Scripts/` into your project's `Assets/Scripts/`
4. Tag Emily as `Player`: select Emily → Inspector → Tag → `Player`
5. Emily needs: `EmilyMover` + `FireStick` + `EmilyCourage` + Rigidbody + Collider

### Scene building

**Intro (ShipIntro + StoryNarrator):**
- Create empty `IntroDirector`, add `ShipIntro` + `StoryNarrator`
- Group 1 "ShipScene": sea plane, ship (cube), storm clouds (inactive)
- Group 2 "ForestScene": everything below (starts inactive)
- (Optional) Record the 6 story lines as AudioClips and drag into StoryNarrator, or use the free "Emily" read-aloud MP3s

**Forest (in ForestScene):**
- Ground plane (10,1,10), hut (small cube), Emily (small capsule) at the hut
- 8–10 cylinders as trees on one side (dark forest)
- Fireflies: 6–8 small glowing spheres with `Firefly` script, trailing from hut to waterfall
- Waterfall: tall cube (blue) + cave opening; Ava (capsule) inside with `AvaRescue` + trigger collider
- Clues: 3 small objects with `ForestClue` script + trigger colliders
- Parents: empty `Parents` (inactive) with 2 capsules + `ParentsRescue` + trigger collider

**Dangers:**
- Tiger: bigger capsule/box, orange — add `ForestDanger` (chaseSpeed 4.5, chaseRange 9)
- Snakes x2: smaller, green — add `ForestDanger` (chaseSpeed 3, chaseRange 7)
- All need trigger colliders

**Managers & UI:**
- Empty `StoryManager` + `StoryManager` script (drag story Text + EndingDirector in)
- Empty `EndingDirector` + `RescueEnding` script
- Canvas: `StoryText` (top), `CourageText`, `VictoryText` ("VICTORY!", inactive), `HouseScene` group (inactive)

**Camera:** position (0, 10, -8), rotation X 45.

Press Play! Move with WASD/arrows, F for fire stick.

## Scripts

- `EmilyMover.cs` — gentle movement, faces where she walks
- `EmilyCourage.cs` — 3 hearts, lose 1 per touch, back to hut at 0
- `FireStick.cs` — F key stuns nearby dangers for 3s, 5s cooldown
- `ForestDanger.cs` — tiger/snake AI: chases in range, gives up when outrun, stunnable
- `ShipIntro.cs` — opening movie: sail → storm → sink → forest
- `StoryNarrator.cs` — plays recorded voice lines per scene
- `StoryManager.cs` — quest stages: Intro → FindAva → FindParents → Rescue → Victory
- `Firefly.cs` — bobbing glow trail to Ava's cave
- `AvaRescue.cs` — rescue Ava, she follows Emily
- `ForestClue.cs` — spinning clues revealing parents
- `ParentsRescue.cs` — triggers the rescue ship ending
- `RescueEnding.cs` — ship sails in, family boards, home + VICTORY!

## Build for Windows

File → Build Settings → Add Open Scenes → PC, Mac & Linux Standalone → Windows x86_64 → Build!
