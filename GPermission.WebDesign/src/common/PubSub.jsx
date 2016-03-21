let events = {};

const PubSub = {
  on: (event, fn) => {
    if (!events[event]) {
      events[event] = [];
    }
    events[event].push(fn);
  },
  off: (event, fn) => {
    const fns = events[event];

    if (!fns) {
      return;
    }

    if (!fn && fns) {
      fns.length = 0;
    } else {
      for (let i = fns.length - 1; i >= 0; i--) {
        if (fn === fns[i]) {
          fns.splice(i, 1);
        }
      }
    }
  },
  trigger: (event, ...data) => {
    const fns = events[event];

    if (!fns || fns.length === 0) {
      return;
    }

    for (let i = 0; i < fns.length; i++) {
      fns[i](...data);
    }
  },
};

export default PubSub;
