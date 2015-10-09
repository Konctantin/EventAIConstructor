using EventIAConstructor.EventAIMetadata;
using System.Windows;
using System.Windows.Controls;

namespace EventIAConstructor.ViewModel
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
                    var template = element.FindResource($"EventType.{modelItem.Type}") as DataTemplate;
                    if (template != null)
                        return template;
                }
                return element.FindResource("EventType.NOT_IMPLEMENTED") as DataTemplate;
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
                if (modelItem != null && modelItem.Type == EventType.RECEIVE_EMOTE)
                {
                    var condition = (ConditionType)modelItem.Param2;
                    var template = element.FindResource($"ConditionType.{condition}") as DataTemplate;
                    if (template != null)
                        return template;
                }
                return element.FindResource("ConditionType.NOT_IMPLEMENTED") as DataTemplate;
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
                    var template = element.FindResource($"ActionType.{modelItem.Type}") as DataTemplate;
                    if (template != null)
                        return template;
                }
                return element.FindResource("ActionType.NOT_IMPLEMENTED") as DataTemplate;
            }

            return null;
        }
    }
}
