import HttpClient from '../utils/httpClient';

const endPoint = `${process.env.VUE_APP_API_BACKEND}/api/invitation`;

const getInvitationById = async id => {
  const httpClient = new HttpClient();
  try {
    const data = await httpClient.getAsync(`${endPoint}/${id}`);
    return data;
  } catch (error) {
    throw error;
  }
};

export default {
  getInvitationById,
};
