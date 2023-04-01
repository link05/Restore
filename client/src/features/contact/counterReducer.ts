
export interface CounterState {
    data: number;
    title:string;
}

const initialState: CounterState = {
    data:42,
    title: 'YARC (Yet another redux counter)'
}

export default function CounterReducer(state = initialState, action:any) {
    return state;
}