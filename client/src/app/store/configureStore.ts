import { createStore } from "redux";
import CounterReducer from "../../features/contact/counterReducer";


export function configureStore() {
    return createStore(CounterReducer)
}