using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private LevelsConfig _levelsConfig;
    [SerializeField] private Player _player;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private string _savePath;
    [SerializeField] private WinWindow _winWindow;
    [SerializeField] private LoseWindow _loseWindow;
    [SerializeField] private GemWindow _gemWindow;
    [SerializeField] private Button _touchButton;
    [SerializeField] private RestartButton _restartButton;
    [SerializeField] private TextMeshProUGUI _tapText;

    private GameStateMachine _gameStateMachine;
    private PlayerStateMachine _playerStateMachine;
    private ILevelFactory _levelFactory;
    private IPlayerFactory _playerFactory;
    private ISaver _saver;
    private ILoader _loader;
    private EventBus _eventBus;
    private IInput _input;
    private GemCounter _gemCounter;
    private IStarCalculator _starCalculator;

    private void Awake()
    {
        ServiceLocator.InitServiceLocator();

        _eventBus = new EventBus();

        _gemCounter = new GemCounter();
        _starCalculator = new StarCalculator();

        _levelFactory = new RandomLevelFactory(_levelsConfig);
        _playerFactory = new PlayerFactory(_player);

        _gameStateMachine = new GameStateMachine();
        _playerStateMachine = new PlayerStateMachine();

        _saver = new JsonSaver(_savePath);
        _loader = new JsonLoader(_savePath);

        ServiceLocator.Instance.AddService<EventBus>(_eventBus);
        _input = new Input(_touchButton);
        ServiceLocator.Instance.AddService<IInput>(_input);
        ServiceLocator.Instance.AddService<ISaver>(_saver);
        ServiceLocator.Instance.AddService<ILoader>(_loader);
        ServiceLocator.Instance.AddService<GemCounter>(_gemCounter);
        ServiceLocator.Instance.AddService<IStarCalculator>(_starCalculator);
        ServiceLocator.Instance.AddService<ILevelFactory>(_levelFactory);
        ServiceLocator.Instance.AddService<IPlayerFactory>(_playerFactory);
        ServiceLocator.Instance.AddService<GameStateMachine>(_gameStateMachine);
        ServiceLocator.Instance.AddService<PlayerStateMachine>(_playerStateMachine);


        _gameStateMachine.AddState(new StartGameState(_camera));
        _gameStateMachine.AddState(new WaitTapState(_gemWindow, _tapText));

        _gameStateMachine.SwitchState<StartGameState>();

        _gameStateMachine.AddState(new GamePlayState(_restartButton));
        _gameStateMachine.AddState(new PreFinishState());
        _gameStateMachine.AddState(new FinishState());
        _gameStateMachine.AddState(new WinState(_winWindow));
        _gameStateMachine.AddState(new LoseState(_loseWindow));

        _playerStateMachine.AddState(new IdleState());
        _playerStateMachine.AddState(new ForwardMovementState());
        _playerStateMachine.AddState(new SingleMovementState());
        _playerStateMachine.AddState(new DoubleMovementState());
        _playerStateMachine.AddState(new MergeState());
    }
}