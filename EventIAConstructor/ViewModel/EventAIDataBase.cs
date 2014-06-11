using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventIAConstructor.ViewModel
{
    public class EventAIDataBase
    {
        static EventAIDataBase()
        {
            Instance = new EventAIDataBase();

            EventAIList = new ObservableCollection<EventAIModel>()
            {
                new EventAIModel() { Id = 1, CreatureId = 2,
                    EventValues = new int[] { 5,  6, 44, 756 }, EventType = EventAIMetadata.EventType.TARGET_MANA,  
                    ActionValue1 = new int[] { 4, 6, 2 },ActionType1 = EventAIMetadata.ActionType.TEXT, 
                    ActionValue2 = new int[] { 3, 4, 1 },ActionType2 = EventAIMetadata.ActionType.TEXT, 
                    ActionValue3 = new int[] { 1, 3, 3 },ActionType3 = EventAIMetadata.ActionType.TEXT,
                },
                new EventAIModel() { Id = 2, CreatureId = 5,
                    EventValues = new int[] { 6, 7, 5, 76 },EventType = EventAIMetadata.EventType.SPELLHIT,
                    ActionValue1 = new int[] { 3, 1, 4 },ActionType1 = EventAIMetadata.ActionType.TEXT, 
                    ActionValue2 = new int[] { 4, 3, 5 },ActionType2 = EventAIMetadata.ActionType.TEXT, 
                    ActionValue3 = new int[] { 5, 2, 6 },ActionType3 = EventAIMetadata.ActionType.TEXT,
                },
            };
        }

        public EventAIDataBase()
        {

        }

        public static EventAIDataBase Instance { get; private set; }

        public static ObservableCollection<EventAIModel> EventAIList { get; set; }
    }
}
