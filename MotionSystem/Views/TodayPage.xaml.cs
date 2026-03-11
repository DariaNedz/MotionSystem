using MotionSystem.Models;
using System.Collections.ObjectModel;

namespace MotionSystem.Views;

public partial class TodayPage : ContentPage
{
    // ===== DATA =====
    private ObservableCollection<ExerciseItem> _exercises;

    private int _totalXpToday;
    private int _earnedXpToday;

    private bool _daySaved = false;

    // timer
    private CancellationTokenSource _restTimerToken;

    public TodayPage()
    {
        InitializeComponent();
        InitializeExercises();
        BuildExercisesUI();
        UpdateProgress();
    }

    // ===== INIT =====
    private void InitializeExercises()
    {
        _exercises = new ObservableCollection<ExerciseItem>
        {
            new ExerciseItem
            {
                Name = "Glute Bridge",
                Xp = 2,
                RequiresRest = true,
                RestSeconds = 45
            },
            new ExerciseItem
            {
                Name = "Seated Forward Fold",
                Xp = 3,
                RequiresRest = false
            },
            new ExerciseItem
            {
                Name = "Plank (30 sec)",
                Xp = 2,
                RequiresRest = true,
                RestSeconds = 60
            }
        };

        _totalXpToday = _exercises.Sum(e => e.Xp);
    }

    // ===== UI BUILD =====
    private void BuildExercisesUI()
    {
        ExercisesContainer.Children.Clear();

        foreach (var exercise in _exercises)
        {
            var checkBox = new CheckBox();
            checkBox.CheckedChanged += (s, e) =>
                OnExerciseChecked(exercise, e.Value);

            var nameLabel = new Label
            {
                Text = exercise.Name,
                TextColor = (Color)Application.Current.Resources["TextPrimary"],
                VerticalOptions = LayoutOptions.Center
            };

            var xpLabel = new Label
            {
                Text = $"{exercise.Xp} XP",
                TextColor = (Color)Application.Current.Resources["TextSecondary"],
                VerticalOptions = LayoutOptions.Center
            };

            var grid = new Grid
            {
                ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Auto },
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Auto }
            }
            };

            grid.Add(checkBox, 0, 0);
            grid.Add(nameLabel, 1, 0);
            grid.Add(xpLabel, 2, 0);

            var frame = new Frame
            {
                BackgroundColor = (Color)Application.Current.Resources["BgCard"],
                CornerRadius = 16,
                Padding = 14,
                Content = grid
            };

            ExercisesContainer.Children.Add(frame);
        }
    }

    // ===== CHECKBOX LOGIC =====
    private async void OnExerciseChecked(ExerciseItem exercise, bool isChecked)
    {
        if (_daySaved) return;

        exercise.IsCompleted = isChecked;
        UpdateProgress();

        if (isChecked && exercise.RequiresRest)
        {
            await StartRestTimer(exercise.RestSeconds);
        }
    }

    // ===== PROGRESS =====
    private void UpdateProgress()
    {
        _earnedXpToday = _exercises
            .Where(e => e.IsCompleted)
            .Sum(e => e.Xp);

        TodayStretchProgress.Progress =
            _totalXpToday == 0
                ? 0
                : (double)_earnedXpToday / _totalXpToday;
    }

    // ===== REST TIMER =====
    private async Task StartRestTimer(int seconds)
    {
        _restTimerToken?.Cancel();
        _restTimerToken = new CancellationTokenSource();

        RestTimerBlock.IsVisible = true;

        try
        {
            for (int i = seconds; i >= 0; i--)
            {
                RestTimerText.Text = TimeSpan
                    .FromSeconds(i)
                    .ToString(@"mm\:ss");

                await Task.Delay(1000, _restTimerToken.Token);
            }
        }
        catch (TaskCanceledException)
        {
            // ignored
        }
        finally
        {
            RestTimerBlock.IsVisible = false;
        }
    }

    // ===== SAVE DAY =====
    private void OnSaveDayClicked(object sender, EventArgs e)
    {
        if (_daySaved) return;

        _daySaved = true;

        SaveDayButton.IsEnabled = false;
        SaveDayButton.Text = "SAVED";
    }
}
