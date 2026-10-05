# Emily's Adventure — Find Ava and Mom & Dad

A cute 3D adventure based on Emily's story. You play as little Emily, following twinkly fireflies to find her big sister Ava in the cave behind the waterfall, then together finding Mommy and Daddy in the dark forest.

## Story

Hi! I'm Emily! After our ship sank, me, my big sister Ava, and Mommy and Daddy lived in a hut in the forest. Then Mommy and Daddy went to find food and never came back. Ava went to light a signal fire on the tall rock but got stuck in a cave behind the waterfall. Now it's up to you (as Emily) to find them all!

## How to play

1. **Find Ava first**: Follow the glowing fireflies from the hut to the waterfall cave. Touch Ava to rescue her — she'll follow you now!
2. **Find the clues**: With Ava following, explore the dark forest and touch 3 clues (Daddy's hat, Mommy's scarf, footprints). Each shows a story message.
3. **Find Mom & Dad**: After all 3 clues, Mom and Dad appear in the forest. Touch them to win!

## Setup (Windows, Unity)

1. Install Unity Hub + latest LTS with Windows Build Support (see main README for detail)
2. Create a new **3D (Core)** project called `EmilysAdventure`
3. Copy all `.cs` files from `Assets/Scripts/` into your project's `Assets/Scripts/`
4. Tag your Emily player as `Player`:
   - Select Emily in Hierarchy → Inspector → Tag → `Player` (add the tag if needed)
   - Emily needs: `EmilyMover` + Rigidbody + Collider

### Scene building

**Hut area (start):**
- Plane (scale 10,1,10) for ground, a small cube as the hut
- Emily (small capsule, scale 0.8) at the hut

**Firefly trail to waterfall:**
- Create 6-8 small spheres (scale 0.2), add `Firefly` script, give them emissive yellow material
- Make a trail from hut toward one side of the map

**Waterfall cave (Ava):**
- A big cube as the rock/waterfall wall, a small opening
- Ava (capsule, scale 1.0, different color) inside, with `AvaRescue` + Collider (Is Trigger checked)

**Dark forest (parents + clues):**
- Scatter 8-10 cylinders as trees on the other side
- 3 small objects as clues with `ForestClue` script + Is Trigger:
  - Clue 1: "This is Daddy's hat! They went this way!"
  - Clue 2: "This is Mommy's scarf! We're close!"
  - Clue 3: "Footprints! Mommy and Daddy were here!"
- Create an empty called `Parents`, add two capsules (Mom and Dad), add `ParentsRescue` + Collider (Is Trigger), set `Parents` to **Inactive** to start

**UI:**
- Canvas + TextMeshPro text called `StoryText` at the top for story messages
- Create empty `StoryManager`, add `StoryManager` script, drag StoryText into its slot

Press Play! Move with WASD, follow the fireflies!

## Scripts

- `EmilyMover.cs` — Emily's gentle movement, faces where she walks
- `StoryManager.cs` — quest stages: Find Ava → Find Parents → Win, shows story text
- `Firefly.cs` — cute bobbing glow that leads the way
- `AvaRescue.cs` — when Emily touches Ava, Ava is rescued and follows Emily
- `ForestClue.cs` — spinning clues, shows message, counts down to reveal parents
- `ParentsRescue.cs` — touching Mom and Dad wins the game

Have fun, brave Emily!
