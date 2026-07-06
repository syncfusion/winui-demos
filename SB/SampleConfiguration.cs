namespace Syncfusion.SampleBrowser.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {

#if GRID_SDK
            new DataGridDemos.WinUI.SamplesConfiguration();
            new TreeGridDemos.WinUI.SamplesConfiguration();
#elif GANTT_SDK
            new KanbanDemos.WinUI.SamplesConfiguration();
#elif SCHEDULER_SDK
            new SchedulerDemos.WinUI.SamplesConfiguration();
            new CalendarDemos.WinUI.SamplesConfiguration();
            new DateTimeDemos.WinUI.SamplesConfiguration();
#elif CHART_SDK
            new ChartDemos.WinUI.SamplesConfiguration();
            new RadialGaugeDemos.WinUI.SamplesConfiguration();
            new LinearGaugeDemos.WinUI.SamplesConfiguration();
            new BarcodeDemos.WinUI.SamplesConfiguration();
#endif
#if UISuiteSDK
            new MarkdownViewerDemos.WinUI.SamplesConfiguration();
            new ChartDemos.WinUI.SamplesConfiguration();
            new RadialGaugeDemos.WinUI.SamplesConfiguration();
            new LinearGaugeDemos.WinUI.SamplesConfiguration();
            new BarcodeDemos.WinUI.SamplesConfiguration();
            new RibbonDemos.WinUI.SamplesConfiguration();
            new TreeViewDemos.WinUI.SamplesConfiguration();
            new SliderDemos.WinUI.SamplesConfiguration();
            new AvatarViewDemos.WinUI.SamplesConfiguration();
            new EditorDemos.WinUI.SamplesConfiguration();
            new CalendarDemos.WinUI.SamplesConfiguration();
            new ShadowDemos.WinUI.SamplesConfiguration();
            new ShimmerDemos.WinUI.SamplesConfiguration();
            new ChatDemos.WinUI.SamplesConfiguration();
            new NotificationDemos.WinUI.SamplesConfiguration();
			new DataGridDemos.WinUI.SamplesConfiguration();
            new TreeGridDemos.WinUI.SamplesConfiguration();

#endif

#if COMPLETE
            new SchedulerDemos.WinUI.SamplesConfiguration();
            new KanbanDemos.WinUI.SamplesConfiguration();
#endif

#if !DOCUMENT_SDK && !GRID_SDK && !UISuiteSDK && !SCHEDULER_SDK && !GANTT_SDK && !CHART_SDK
            new ChartDemos.WinUI.SamplesConfiguration();
            new RadialGaugeDemos.WinUI.SamplesConfiguration();
            new LinearGaugeDemos.WinUI.SamplesConfiguration();
            new BarcodeDemos.WinUI.SamplesConfiguration();        
            new SchedulerDemos.WinUI.SamplesConfiguration();          
            new CalendarDemos.WinUI.SamplesConfiguration();
			new ChatDemos.WinUI.SamplesConfiguration();
            new KanbanDemos.WinUI.SamplesConfiguration();
#endif
#if !UISuiteSDK && !GRID_SDK && !SCHEDULER_SDK && !GANTT_SDK && !CHART_SDK
            new DocIODemos.WinUI.SamplesConfiguration();
            new PdfDemos.WinUI.SamplesConfiguration();
            new PresentationDemos.WinUI.SamplesConfiguration();
            new XlsIODemos.WinUI.SamplesConfiguration();
            new MarkdownDemos.WinUI.SamplesConfiguration();
#endif
        }
    }
}
