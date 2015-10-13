using EventIAConstructor.EventAI.Metadata;
using System.Windows;
using System.Windows.Controls;

namespace EventIAConstructor.EventAI.ViewModel
{
    public class EventDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;

            if (element != null && item is EventModel)
            {
                var modelItem = item as EventModel;
                if (modelItem != null)
                {
                    var name = (EventType)modelItem.Type;
                    var template = element.TryFindResource($"EventType.{name}") as DataTemplate;
                    if (template != null)
                        return template;
                }
                return element.TryFindResource("EventType.NOT_IMPLEMENTED") as DataTemplate;
            }

            return null;
        }
    }

    public class ConditionDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;

            if (element != null && item is EventModel)
            {
                var modelItem = item as EventModel;
                var eventType = (EventType)modelItem.Type;
                if (modelItem != null && eventType == EventType.RECEIVE_EMOTE)
                {
                    var name = (ConditionType)modelItem.Param2;
                    var template = element.TryFindResource($"ConditionType.{name}") as DataTemplate;
                    if (template != null)
                        return template;
                }
                return element.TryFindResource("ConditionType.NOT_IMPLEMENTED") as DataTemplate;
            }

            return null;
        }
    }

    public class ActionDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;

            if (element != null && item is ActionModel)
            {
                var modelItem = item as ActionModel;
                if (modelItem != null)
                {
                    var name = (ActionType)modelItem.Type;
                    var template = element.TryFindResource($"ActionType.{name}") as DataTemplate;
                    if (template != null)
                        return template;
                }
                return element.TryFindResource("ActionType.NOT_IMPLEMENTED") as DataTemplate;
            }

            return null;
        }
    }
}