
namespace EventIAConstructor.EventAIMetadata
{
    public enum ConditionType : int
    {
        NONE            = 0,    // 0            0
        AURA            = 1,    // spell_id     effindex
        ITEM            = 2,    // item_id      count
        ITEM_EQUIPPED   = 3,    // item_id      count
        ZONEID          = 4,    // zone_id      0
        REPUTATION_RANK = 5,    // faction_id   min_rank
        TEAM            = 6,    // player_team  0 (469-Alliance / 67-Horde)
        SKILL           = 7,    // skill_id     min_skill_value
        QUESTREWARDED   = 8,    // quest_id     0, if quest are rewarded
        QUESTTAKEN      = 9,    // quest_id     0, while quest active(incomplete)
        ACTIVE_EVENT    = 12,   // event_id     0, note this is id from dbc, also defined in Mangos source(enum HolidayIds) NOT id of game_event in database    };
    }
}
