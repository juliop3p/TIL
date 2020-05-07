## Redux Setup

#### 1) First you need to install 2 dependencies

`yarn add redux react-redux`

_And then you need to create the following directory structure_

<pre>
|- src
|  |- store
|  | |- modules
|  | | |- cart
|  | | |  |- reducer.js
|  | | |- rootReducer.js
|    |- index.js
</pre>

#### 2) It's necessary to wrap the entire project in the Provider:

```
import React from 'react';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux'; // here

import GlobalStyle from './styles/global';
import Header from './components/Header/index';

import Routes from './routes';

import store from './store'; // here

function App() {
  return (
    <Provider store={store}> // here
      <BrowserRouter>
        <Header />
        <Routes />
        <GlobalStyle />
      </BrowserRouter>
    </Provider> // here
  );
}

export default App;

```

#### 3) index.js

```
import { createStore } from 'redux';

import rootReducer from './modules/rootReducer';

const store = createStore(rootReducer);

export default store;
```

#### 3) rootReducer.js

```
import { combineReducers } from 'redux';

import cart from './cart/reducer';

export default combineReducers({
  cart,
});
```

#### 3) reducer.js

```
export default function cart() {
  return [];
}
```

## Reactotron + Redux

1. `yarn add reactotron-react-js reactotron-redux`

_directory structure_

<pre>
|- src
|  |- config
|  | |- ReactotronConfig.js
|  |
</pre>

3. ReactotronConfig.js

<pre>
import Reactotron from 'reactotron-react-js';
import { reactotronRedux } from 'reactotron-redux';

if (process.env.NODE_ENV === 'development') {
  const tron = Reactotron.configure().use(reactotronRedux()).connect();
  tron.clear();
  console.tron = tron;
}
</pre>

4. store.js
<pre>
import { createStore } from 'redux';

import rootReducer from './modules/rootReducer';

const enhancer =
process.env.NODE_ENV === 'development' ? console.tron.createEnhancer() : null;

const store = createStore(rootReducer, enhancer);

export default store;

</pre>

5. And the last important thing you need to import the config file on your App.js.
   `import './config/ReactotronConfig';`
   _It's important to be called before the redux store_

## Redux Saga

`yarn add redux-saga`

<pre>
|-store
| |- modules
| | |- cart
| | |  |- actions.js
| | |  |- reducer.js
| | |  |- sagas.js
| | |- rootReducer
| | |- rootSaga.js
| |-index.js
</pre>

#### sagas.js

<pre>
import { call, put, all, takeLatest } from 'redux-saga/effects';
// call for asynchronous/promisses methods
// put to create a action on redux
// all to register listeners (actions)
// takeLatest take the latest call (action)

import api from '../../../services/api';

import { addToCartSuccess } from './actions';

function* addToCart({ id }) {
  const response = yield call(api.get, `/products/${id}`);

  yield put(addToCartSuccess(response.data));
}

export default all([takeLatest('@cart/ADD_REQUEST', addToCart)]);
</pre>

#### actions.js

<pre>
export function addToCartRequest(id) {
  return {
    type: '@cart/ADD_REQUEST',
    id,
  };
}

export function addToCartSuccess(product) {
  return {
    type: '@cart/ADD_SUCCESS',
    product,
  };
}
</pre>

#### reducer.js

<pre>
case '@cart/ADD_SUCCESS':
  return produce(state, draft => {
    const productIndex = draft.findIndex(p => p.id === action.product.id);

    if (productIndex >= 0) {
      draft[productIndex].amount += 1;
    } else {
      draft.push({
        ...action.product,
        amount: 1,
      });
    }
  });
</pre>

#### rootSaga.js

<pre>
import { all } from 'redux-saga/effects';

import cart from './cart/sagas';

export default function* rootSaga() {
  return yield all([cart]);
}
</pre>

#### store/index.js

<pre>
import { createStore, applyMiddleware, compose } from 'redux'; // here
import createSagaMiddleware from 'redux-saga'; // here

import rootReducer from './modules/rootReducer';
import rootSaga from './modules/rootSaga'; // here

const sagaMiddleware = createSagaMiddleware(); // here

const enhancer =
  process.env.NODE_ENV === 'development'
    ? compose(console.tron.createEnhancer(), applyMiddleware(sagaMiddleware))
    : applyMiddleware(sagaMiddleware); // here

const store = createStore(rootReducer, enhancer);

sagaMiddleware.run(rootSaga); // here

export default store;

</pre>

#### home.js

<pre>
handleAddProduct = id => {
  const { addToCartRequest } = this.props;

  addToCartRequest(id);
};
</pre>
