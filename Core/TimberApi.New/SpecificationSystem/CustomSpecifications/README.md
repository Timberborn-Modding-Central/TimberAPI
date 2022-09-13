# TimberAPI custom specifications

These specifications provide a workaround to certain features to improve the modding experience or fix bugs.

## Faction golem

**What:** Reusing golem models in other factions or creating custom golem models  
**When:** Creating new faction specifications  
**Why:** GolemId is hardcode to the factionId

## Building Specifications
Building Specifications are custom specification that enable changing some things on existing buildings.
The changeable things are:
* Buildings costs
* Recipes
* Power input/output values
  These specs were made because Timberborn does not yet have json specifications for buildings, which makes
  modifying them bothersome. These custom specs make the modification trivial.