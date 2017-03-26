# Learning by doing **Tools**

## Plan / work

Just use, document notes or gotchas as we go...

## Tools in use

- [ ] [Cygwin.md](Tools/Cygwin.md)
- [ ] [Screen.md](Tools/Screen.md)
- [ ] [Vim.md](Tools/Vim.md)
- [ ] [Visualstudio.md](Tools/Visualstudio.md) *Hmm...?*
	- [ ] NuGET  (.NET per *solution* package manager)
	- [ ] Resharper

**Note:** Only those worth documenting will have a working link above.

# Temporary notes:

## Vim

### Terminal colors

1. make sure `/etc/DIR_COLORS` is used by the terminal.
 - If in `Cygwin/MingW`, this is controlled by `/etc/bash.bashrc`.
	Follow the comment and remove the remark the line
	`eval "$(dircolors -b /etc/DIR_COLORS)"`
2. If running `Screen`, the environment variable `TERM` is prepended with
   the string `screen.`
 - `echo $TERM` and add a better clobbered filter in  `/etc/DIR_COLORS`.
       For example as follows:
```bash
# Screen terminal-emulator workaround
# We don't know if the terminal attached to screen will handle 256 colors
# but we'll ignore that fact and go for best effort (Works on Windows)
TERM screen.xterm*
```

