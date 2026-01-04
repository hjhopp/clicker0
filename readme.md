# Clicker0, A Starter Godot Project

This is meant to be a vertical slice of a basic game built in Godot, from version control, testing, CI/CD, and the game itself.

`Clicker0` is a bare-bones incremental game. Click the button and fun things happen!

## Criteria for success

### GODOT

- [x] Clicking a button causes a "Score" number to iterate on the screen
    - [x] Particle effects
    - [x] Clicking audio effect
- [ ] Clicking a button changes the background of the screen
    - [ ] This background varies from static 2D, to animated 2D, to animated 3D
- [ ] Clicking a button changes the shader on the button
- [ ] The button is localized and we have a language selector
- [ ] Change game icon
- [ ] Window / Full screen option
- [ ] Usable with a controller
- [ ] Score persists between sessions
    - [ ] New Game feature that brings everything back to initial

### INFRASTRUCTURE

- [x] This game is tested
- [x] Game features are developed on their own branches
- [ ] Integration with main branch should pass all tests
- [ ] Integration with main branch deploys built product for distribution

## Testing

This game uses GdUnit4 for testing.

## Debugging

### Game

In VSCode, press Play in the debugger for "Attach to Game" to hit breakpoints set in your game code.

### Tests

In VSCode, press Play in the debugger for "Attach to Tests" to hit breakpoints set in your test code.

Run `./runtests.sh` at project root to just run the tests without the debugger.